using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class VariableScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal VariableScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
    }
}