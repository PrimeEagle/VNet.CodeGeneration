using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class CodeGroupingScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal CodeGroupingScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public CodeGroupingScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public override void Dispose()
        {
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetCodeGroupingCloseScope(StyledValue, IndentLevel.Current));
        }

        public CodeGroupingScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public CodeGroupingScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public CodeGroupingScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetCodeGroupingOpenScope(StyledValue, IndentLevel.Current));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}