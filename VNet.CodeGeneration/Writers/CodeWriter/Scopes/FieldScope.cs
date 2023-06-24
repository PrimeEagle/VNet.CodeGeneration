using System;
using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class FieldScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private readonly List<string> _modifiers;
        private string _type;

        internal FieldScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _modifiers = new List<string>();
        }

        public FieldScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
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

        public FieldScope OfType(string type)
        {
            _type = type;

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);
            if (string.IsNullOrEmpty(_type)) throw new ArgumentException($"Field type cannot be empty or null.");

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetFieldStyledSyntax(StyledValue, _type, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }

        public override void Dispose()
        {
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetFieldPostScopeStyledSyntax(StyledValue, _type, Modifiers, IndentLevel));
        }
    }
}