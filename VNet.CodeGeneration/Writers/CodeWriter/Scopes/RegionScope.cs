using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class RegionScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal RegionScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public override void Dispose()
        {
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetRegionCloseScope(StyledValue, IndentLevel.Current));
        }

        public RegionScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public RegionScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public RegionScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetRegionOpenScope(StyledValue, IndentLevel.Current));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}