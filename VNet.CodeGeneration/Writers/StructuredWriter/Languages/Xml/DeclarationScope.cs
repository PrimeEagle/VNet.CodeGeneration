using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class DeclarationScope : XmlExtendedLineScope<DeclarationScope>
    {
        private string _version;
        private string _encoding;
        private string _standalone;

        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => "<?xml ";
        protected override string AlternateOpenScopeCloseSymbol => " ?>";


        public DeclarationScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public DeclarationScope WithVersion(string version)
        {
            _version = version;

            return this;
        }

        public DeclarationScope WithEncoding(string encoding)
        {
            _encoding = encoding;

            return this;
        }

        public DeclarationScope WithStandalone(string standalone)
        {
            _standalone = standalone;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var ver = $" version{SpOp}={SpOp}{Qu}{_version}{Qu}";
            var enc = $" encoding{SpOp}={SpOp}{Qu}{_encoding}{Qu}";
            var stn = $" standalone{SpOp}={SpOp}{Qu}{_standalone}{Qu}";

            result.InsideOpenScope.Add($"{ver}{enc}{stn}");
        }
    }
}