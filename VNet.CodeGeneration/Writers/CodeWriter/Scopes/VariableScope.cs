using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
#pragma warning disable IDE0052

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
            Modifiers = new List<string>();
        }

        public VariableScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public VariableScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public VariableScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
    }
}