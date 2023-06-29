using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class EnumScope : IndentedBlockScope
    {
        private readonly List<EnumerationMember> _members;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.EnumerationCaseConversionStyle;


        public EnumScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _members = new List<EnumerationMember>();
        }

        public EnumScope AddBlankLine()
        {
            var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public EnumScope AddBlankLines(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
                AddNestedScope(result);
            }

            return this;
        }

        public EnumScope AddCodeLine(string text)
        {
            var result = new CodeLineScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CodeBlockScope AddCodeBlock(string text)
        {
            var result = new CodeBlockScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
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

        protected override void WriteCodeLines(CodeResult result)
        {
            result.OpenScopeLines.Add($"enum {StyledValue}");
        }
    }
}