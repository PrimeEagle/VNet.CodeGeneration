using System.Collections.Generic;
using VNet.CodeGeneration.Writers;
using VNet.CodeGeneration.Writers.StructuredWriter;


namespace VNet.Scientific.CodeGen.Writers.StructuredWriter.Languages.Markdown
{
    public class MarkdownCodeFile : MarkdownBlockScope<MarkdownCodeFile>, IStructuredLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => string.Empty;
        protected override string AlternateOpenScopeCloseSymbol => string.Empty;
        protected override string AlternateCloseScopeOpenSymbol => string.Empty;
        protected override string AlternateCloseScopeCloseSymbol => string.Empty;

        protected MarkdownCodeFile(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        internal MarkdownCodeFile() : base(null, null, new MarkdownLanguageSettings(new MarkdownDefaultStyle()), null, new IndentationManager(), new List<string>())
        {
        }

        public MarkdownCodeFile WithStyle(IStructuredLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}