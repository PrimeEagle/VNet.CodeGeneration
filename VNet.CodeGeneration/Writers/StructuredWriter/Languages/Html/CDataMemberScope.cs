using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class CDataMemberScope : HtmlBlockScope<CDataMemberScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => "<![CDATA[";
        protected override string AlternateCloseScopeCloseSymbol => "]]>";


        public CDataMemberScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            result.ScopedCodeLines.Add($"{StyledValue}");
        }
    }
}