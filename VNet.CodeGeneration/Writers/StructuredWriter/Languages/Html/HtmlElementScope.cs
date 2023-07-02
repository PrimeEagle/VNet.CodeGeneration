using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class HtmlElementScope : HtmlBlockScope<StandardElementScope>
    {
        private string _content;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public HtmlElementScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public BodyElementScope AddBody(string name)
        {
            var result = new BodyElementScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public HtmlElementScope WithContent(string name)
        {
            _content = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.InsideOpenScope.Add($"{StyledValue}");
            result.ScopedCodeLines.Add($"{_content}");
        }
    }
}