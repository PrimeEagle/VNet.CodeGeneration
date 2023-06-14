using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverUpdated.Local
#pragma warning disable IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class DelegateScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private string _returnType;
        private readonly List<string> _parameters;

        internal DelegateScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
            _parameters = new List<string>();
            _returnType = LanguageSettings.Syntax.VoidKeyword;
        }

        public DelegateScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
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

        public DelegateScope WithReturnType(string returnType)
        {
            _returnType = returnType;

            return this;
        }

        public DelegateScope WithParameter(string parameter)
        {
            _parameters.Add(parameter);

            return this;
        }

        public override void Dispose()
        {
            
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetDelegateStyledSyntax(StyledValue, _returnType, _parameters, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}