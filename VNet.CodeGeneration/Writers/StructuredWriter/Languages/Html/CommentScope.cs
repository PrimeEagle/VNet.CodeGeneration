using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class CommentScope : HtmlLineScope<CommentScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.CommentCaseConversionStyle;
        protected override string AlternateOpenScopeOpenSymbol => "<!--";
        protected override string AlternateCloseScopeCloseSymbol => "-->";

        public CommentScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }    

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"{StyledValue}");
        }
    }
}