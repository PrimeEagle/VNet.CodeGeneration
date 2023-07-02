using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class XmlCodeFile : XmlBlockScope<XmlCodeFile>, IStructuredLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => string.Empty;
        protected override string AlternateOpenScopeCloseSymbol => string.Empty;
        protected override string AlternateCloseScopeOpenSymbol => string.Empty;
        protected override string AlternateCloseScopeCloseSymbol => string.Empty;

        protected XmlCodeFile(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        internal XmlCodeFile() : base(null, null, new XmlLanguageSettings(new XmlDefaultStyle()), null, new IndentationManager(), new List<string>())
        {
        }

        public XmlCodeFile WithStyle(IStructuredLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        public ElementScope AddElement(string name)
        {
            var result = new ElementScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CDataScope AddCData(string name)
        {
            var result = new CDataScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CommentScope AddComment(string name)
        {
            var result = new CommentScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public DeclarationScope AddDeclaration(string name)
        {
            var result = new DeclarationScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}