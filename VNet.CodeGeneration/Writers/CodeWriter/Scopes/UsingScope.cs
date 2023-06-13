using System.Collections.Generic;
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class UsingScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal UsingScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public UsingScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public UsingScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public UsingScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetUsingStyledSyntax(StyledValue, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}