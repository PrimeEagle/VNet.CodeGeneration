using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class EnumScope : CSharpBlockScope<EnumScope>
    {
        private readonly List<EnumerationMember> _members;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.EnumerationCaseConversionStyle;


        public EnumScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _members = new List<EnumerationMember>();
        }

        public EnumScope AddMember(string name, int? value = null)
        {
            var result = new EnumMemberScope(name, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public EnumScope AddMembers(List<EnumerationMember> members)
        {
            for(var i = 0; i < members.Count; i++)
            {
                AddMember(members[i].Name, members[i].Value);
            }

            return this;
        }

        public EnumScope AddMembers(List<string> names)
        {
            for (var i = 0; i < names.Count; i++)
            {
                AddMember(names[i], null);
            }

            return this;
        }

        public EnumScope Sort()
        {
            // Dictionary to store EnumMemberScope and its preceding scopes
            var scopesDictionary = new Dictionary<EnumMemberScope, List<Scope>>();
            var precedingScopes = new List<Scope>();

            foreach (var scope in Scopes)
            {
                if (scope is EnumMemberScope enumMemberScope)
                {
                    scopesDictionary[enumMemberScope] = precedingScopes;
                    precedingScopes = new List<Scope>();
                }
                else
                {
                    precedingScopes.Add(scope);
                }
            }

            // Clear the scopes list
            Scopes.Clear();

            // Order EnumMemberScopes alphabetically
            foreach (var entry in scopesDictionary.OrderBy(e => e.Key.Value))
            {
                // Add preceding scopes first, then the EnumMemberScope
                Scopes.AddRange(entry.Value);
                Scopes.Add(entry.Key);
            }

            // Add remaining scopes that are not EnumMemberScopes and do not have a following EnumMemberScope
            Scopes.AddRange(precedingScopes);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"enum {StyledValue}");
        }
    }
}