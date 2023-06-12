using System.Collections.Generic;

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
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetUsingStyledSyntax(StyledValue, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}