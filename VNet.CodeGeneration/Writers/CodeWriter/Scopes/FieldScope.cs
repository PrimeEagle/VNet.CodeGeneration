using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable CS0108, CS0114, CS0169, IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class FieldScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private readonly List<string> _modifiers;

        internal FieldScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _modifiers = new List<string>();
        }

        public FieldScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public FieldScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public FieldScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(_modifiers);
            _codeLines.Clear();



            return _codeLines;
        }
    }
}