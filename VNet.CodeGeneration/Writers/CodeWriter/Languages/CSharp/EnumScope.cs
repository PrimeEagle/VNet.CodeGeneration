using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class EnumScope : CSharpBlockScope<EnumScope>
    {
        private List<string> _modifiers;
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.EnumerationCaseConversionStyle;


        public EnumScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public EnumScope AddMember(string name, int? value = null)
        {
            var result = new EnumMemberScope(name, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public EnumScope AddMembers(List<Tuple<string, int?>> members)
        {
            for(var i = 0; i < members.Count; i++)
            {
                AddMember(members[i].Item1, members[i].Item2);
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

            Scopes.Clear();

            foreach (var entry in scopesDictionary.OrderBy(e => e.Key.Value))
            {
                Scopes.AddRange(entry.Value);
                Scopes.Add(entry.Key);
            }

            Scopes.AddRange(precedingScopes);

            return this;
        }

        public EnumScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}enum {StyledValue}");
        }
    }
}