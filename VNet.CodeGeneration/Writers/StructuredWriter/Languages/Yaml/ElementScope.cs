using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class ElementScope : XmlBlockScope<ElementScope>
    {
        private string _content;
        private List<Tuple<string, string>> _attributes;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public ElementScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _attributes = new List<Tuple<string, string>>();
        }    

        public ElementScope WithAttribute(string name, string value)
        {
            _attributes.Add(new Tuple<string, string>(name, value));

            return this;
        }

        public ElementScope WithContent(string name)
        {
            _content = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var attr = _attributes.Select(a => $"{a.Item1}{spOp}={spOp}{qu}{a.Item2}{qu}").ToList();
            var attrList = string.Join(" ", attr);
            if (!string.IsNullOrEmpty(attrList)) attrList = $" {attrList}";

            result.InsideOpenScope.Add($"{StyledValue}{attrList}");
            result.ScopedCodeLines.Add($"{_content}");
        }
    }
}