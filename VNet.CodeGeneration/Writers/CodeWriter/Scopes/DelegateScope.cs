using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class DelegateScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal DelegateScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public DelegateScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public DelegateScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public DelegateScope WithAccessModifier(string accessModifier)
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