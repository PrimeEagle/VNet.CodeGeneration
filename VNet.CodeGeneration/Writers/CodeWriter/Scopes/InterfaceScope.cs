using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class InterfaceScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal InterfaceScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public InterfaceScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public InterfaceScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public InterfaceScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetInterfaceStyledSyntax(StyledValue, Modifiers, IndentLevel));
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
            IndentLevel.Increase();

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}