using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class AccessorScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private string _type;

        internal AccessorScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public AccessorScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public AccessorScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public AccessorScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public AccessorScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public AccessorScope OfType(string type)
        {
            _type = type;

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetAccessorStyledSyntax(StyledValue, _type, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}