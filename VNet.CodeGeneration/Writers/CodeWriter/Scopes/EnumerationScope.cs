using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class EnumerationScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private readonly List<EnumerationMember> _members;

        internal EnumerationScope(string name, Scope parent)
            : base(name, parent)
        {
            _members = new List<EnumerationMember>();
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public EnumerationScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public EnumerationScope WithMember(string name, int? value = null)
        {
            var member = new EnumerationMember(name, value);
            _members.Add(member);

            return this;
        }

        public EnumerationScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public EnumerationScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public EnumerationScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetEnumerationStyledSyntax(StyledValue, Modifiers, IndentLevel, _members));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}