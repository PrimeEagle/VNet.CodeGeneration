using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ModuleScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private ModuleStyle _namespaceStyle;

        internal ModuleScope(string value, Scope parent)
            : base(value, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _namespaceStyle = LanguageSettings.Style.ModuleStyle;
            Modifiers = new List<string>();
        }

        public ModuleScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public ModuleScope WithSingleLineStyle()
        {
            _namespaceStyle = ModuleStyle.SingleLine;

            return this;
        }

        public ModuleScope WithScopedStyle()
        {
            _namespaceStyle = ModuleStyle.Scoped;

            return this;
        }

        public ModuleScope WithModifier(string modifier)
        {
            AddModifier(modifier);


            return this;
        }

        public ModuleScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public ModuleScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public override void Dispose()
        {
            if(_namespaceStyle == ModuleStyle.Scoped) base.Dispose();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            switch (_namespaceStyle)
            {
                case ModuleStyle.Scoped:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetModuleStyledSyntax(StyledValue, Modifiers, IndentLevel, _namespaceStyle));
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
                        IndentLevel.Increase();

                        foreach (var childScope in _scopes)
                            _codeLines.AddRange(childScope.GenerateCode());
                        break;
                    }
                case ModuleStyle.SingleLine:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetModuleStyledSyntax(StyledValue, Modifiers, IndentLevel, _namespaceStyle));

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