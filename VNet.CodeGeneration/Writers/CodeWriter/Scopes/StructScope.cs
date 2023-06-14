using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable IDE0060

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class StructScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal StructScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public StructScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public StructScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public StructScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public StructScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }


        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetStructStyledSyntax(StyledValue, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}