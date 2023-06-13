using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class NamespaceScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private NamespaceStyle _namespaceStyle;

        internal NamespaceScope(string value, Scope parent)
            : base(value, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _namespaceStyle = LanguageSettings.Style.NamespaceStyle;
            Modifiers = new List<string>();
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

        public NamespaceScope WithModifier(string modifier)
        {
            AddModifier(modifier);


            return this;
        }

        public NamespaceScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public NamespaceScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }
        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            switch (_namespaceStyle)
            {
                case NamespaceStyle.Scoped:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetNamespaceStyledSyntax(StyledValue, Modifiers, IndentLevel, _namespaceStyle));
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
                        IndentLevel.Increase();

                        foreach (var childScope in _scopes)
                            _codeLines.AddRange(childScope.GenerateCode());
                        break;
                    }
                case NamespaceStyle.SingleLine:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetNamespaceStyledSyntax(StyledValue, Modifiers, IndentLevel, _namespaceStyle));

                        foreach (var childScope in _scopes)
                            _codeLines.AddRange(childScope.GenerateCode());
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            Dispose();

            return _codeLines;
        }
    }
}