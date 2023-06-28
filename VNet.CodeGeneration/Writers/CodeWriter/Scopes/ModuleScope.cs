using System;
using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ModuleScope : Scope
    {
        private readonly List<string> _codeLines;
        private ModuleStyle _moduleStyle;

        internal ModuleScope(string value, Scope parent)
            : base(value, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _moduleStyle = LanguageSettings.Style.ModuleStyle;
            Modifiers = new List<string>();
        }

        public ModuleScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public ModuleScope WithSingleLineStyle()
        {
            _moduleStyle = ModuleStyle.SingleLine;

            return this;
        }

        public ModuleScope WithScopedStyle()
        {
            _moduleStyle = ModuleStyle.Scoped;

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

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            switch (_moduleStyle)
            {
                case ModuleStyle.Scoped:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetModuleStyledSyntax(StyledValue, _moduleStyle, Modifiers, IndentLevel));
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
                        IndentLevel.Increase();

                        foreach (var childScope in _scopes)
                            _codeLines.AddRange(childScope.GenerateCode());
                        break;
                    }
                case ModuleStyle.SingleLine:
                    {
                        _codeLines.AddRange(LanguageSettings.StyledSyntax.GetModuleStyledSyntax(StyledValue, _moduleStyle, Modifiers, IndentLevel));

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

        public override void Dispose()
        {
            if (_moduleStyle == ModuleStyle.Scoped)
            {
                IndentLevel.Decrease();
                _codeLines.AddRange(LanguageSettings.StyledSyntax.GetCloseScope(IndentLevel.Current));
            }

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetModulePostScopeStyledSyntax(StyledValue, _moduleStyle, Modifiers, IndentLevel));
        }
    }
}