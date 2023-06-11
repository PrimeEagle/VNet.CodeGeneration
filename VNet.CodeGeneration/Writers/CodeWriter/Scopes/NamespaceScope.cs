using System;
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

        public NamespaceScope UseSingleLineStyle()
        {
            _namespaceStyle = NamespaceStyle.SingleLine;
            return this;
        }

        public NamespaceScope UseScopedStyle()
        {
            _namespaceStyle = NamespaceStyle.Scoped;
            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            switch (_namespaceStyle)
            {
                case NamespaceStyle.Scoped:
                    {
                        _codeLines.Add($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.UseStatementKeyword} {StyledName}");
                        _codeLines.AddRange(GenerateOpenScope());

                        foreach (var childScope in _scopes) _codeLines.AddRange(childScope.GenerateCode());

                        _codeLines.AddRange(GenerateCloseScope());
                        LanguageSettings.Style.IndentLevel++;
                        break;
                    }
                case NamespaceStyle.SingleLine:
                    {
                        _codeLines.Add($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.UseStatementKeyword} {StyledName};");

                        foreach (var childScope in _scopes) _codeLines.AddRange(childScope.GenerateCode());

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return _codeLines;
        }
    }
}