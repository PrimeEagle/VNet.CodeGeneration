using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class FunctionScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private string _returnType;
        private readonly List<string> _parameters;
        private readonly List<string> _genericTypes;
        private readonly List<string> _genericConstraints;

        internal FunctionScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
            _parameters = new List<string>();
            _returnType = LanguageSettings.Syntax.VoidKeyword;
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
        }

        public FunctionScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public FunctionScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public FunctionScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public FunctionScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public FunctionScope WithReturnType(string returnType)
        {
            _returnType = returnType;

            return this;
        }

        public FunctionScope WithParameter(string parameter)
        {
            _parameters.Add(parameter);

            return this;
        }

        public FunctionScope WithGenericType(string genericType)
        {
            _genericTypes.Add(genericType);

            return this;
        }

        public FunctionScope WithGenericConstraint(string genericConstraint)
        {
            _genericConstraints.Add(genericConstraint);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetMethodStyledSyntax(StyledValue, _returnType, _genericTypes, _genericConstraints, _parameters, Modifiers, IndentLevel));
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
            IndentLevel.Increase();

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}