using System.Collections.Generic;

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class NamespaceScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private NamespaceStyle _namespaceStyle;

        internal NamespaceScope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
            : base(name, parent, languageSettings)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _namespaceStyle = LanguageSettings.Style.NamespaceStyle;
        }

        public NamespaceScope WithSingleLineStyle()
        {
            _namespaceStyle = NamespaceStyle.SingleLine;

            return this;
        }

        public NamespaceScope WithScopedStyle()
        {
            _namespaceStyle = NamespaceStyle.Scoped;

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetNamespaceCode(StyledName, _namespaceStyle, _scopes, IndentLevel));

            return _codeLines;
        }
    }
}