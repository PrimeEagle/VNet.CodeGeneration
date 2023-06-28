using System.Collections.Generic;
using System.Linq;
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

        public EnumScope WithMember(EnumerationMember member)
        {
            _members.Add(member);

            return this;
        }

        public EnumScope WithMember(string name, int? value = null)
        {
            var member = new EnumerationMember(name, value);
            _members.Add(member);

            return this;
        }

        public EnumScope WithMembers(List<EnumerationMember> members)
        {
            _members.Clear();
            _members.AddRange(members);

            return this;
        }

        public EnumScope WithMembers(List<string> names)
        {
            var members = names.Select(n => new EnumerationMember(n, null));
            _members.Clear();
            _members.AddRange(members);

            return this;
        }

        public EnumScope Sort()
        {
            var sorted = _members.OrderBy(m => m).ToList();
            _members.Clear();
            _members.AddRange(sorted);

            return this;
        }

        protected override void WriteCodeLines()
        {
            return;
        }
    }
}