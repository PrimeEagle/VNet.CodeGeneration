using System.Collections.Generic;
using System.Linq;
#pragma warning disable IDE0052

// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable CS0169

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

        public FieldScope WithStatic()
        {
            AddModifier(LanguageSettings.Syntax.StaticKeyword);

            return this;
        }

        public FieldScope WithReadOnly()
        {
            AddModifier(LanguageSettings.Syntax.ReadOnlyKeyword);

            return this;
        }

        public FieldScope WithConstant()
        {
            AddModifier(LanguageSettings.Syntax.ConstantKeyword);

            return this;
        }

        public FieldScope WithVolatile()
        {
            AddModifier(LanguageSettings.Syntax.VolatileKeyword);

            return this;
        }

        public FieldScope WithNew()
        {
            AddModifier(LanguageSettings.Syntax.NewKeyword);

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