using System;
using System.Collections.Generic;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class VariableScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private readonly List<string> _modifiers;
        private string _type;

        internal VariableScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            _modifiers = new List<string>();
        }

        public VariableScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
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

        public VariableScope OfType(string type)
        {
            _type = type;

            return this;
        }

        public override void Dispose()
        {

        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);
            if (string.IsNullOrEmpty(_type)) throw new ArgumentException($"Variable type cannot be empty or null.");

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetVariableStyledSyntax(StyledValue, _type, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}