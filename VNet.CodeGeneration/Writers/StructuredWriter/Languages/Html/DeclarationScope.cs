using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class DeclarationScope : HtmlExtendedLineScope<DeclarationScope>
    {
        private string _version;
        private string _encoding;
        private string _standalone;

        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => "<!DOCTYPE";
        protected override string AlternateOpenScopeCloseSymbol => ">";


        public DeclarationScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            result.InsideOpenScope.Add($"html");
        }
    }
}