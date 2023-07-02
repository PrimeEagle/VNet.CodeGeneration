using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public class JsonCodeFile : JsonBlockScope<JsonCodeFile>, IStructuredLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => string.Empty;
        protected override string AlternateOpenScopeCloseSymbol => string.Empty;
        protected override string AlternateCloseScopeOpenSymbol => string.Empty;
        protected override string AlternateCloseScopeCloseSymbol => string.Empty;

        protected JsonCodeFile(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        internal JsonCodeFile() : base(null, null, new JsonLanguageSettings(new JsonDefaultStyle()), null, new IndentationManager(), new List<string>())
        {
        }

        public JsonCodeFile WithStyle(IStructuredLanguageStyle style)
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