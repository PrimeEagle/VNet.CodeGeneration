using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class AnchorElementScope : HtmlBlockScope<StandardElementScope>
    {
        private string _content;
        private string _href;


        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public AnchorElementScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }    

        public AnchorElementScope WithContent(string name)
        {
            _content = name;

            return this;
        }

        public AnchorElementScope WithHref(string url)
        {
            _href = url;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var h = !string.IsNullOrEmpty(_href) ? $" href{spOp}={spOp}{qu}{_href}{qu}" : string.Empty;

            result.InsideOpenScope.Add($"{StyledValue}{h}");
            result.ScopedCodeLines.Add($"{_content}");
        }
    }
}