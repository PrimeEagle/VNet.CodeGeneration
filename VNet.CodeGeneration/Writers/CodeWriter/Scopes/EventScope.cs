using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CollectionNeverUpdated.Local

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class EventScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private string _returnType;

        internal EventScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
            _returnType = LanguageSettings.Syntax.VoidKeyword;
        }

        public EventScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public EventScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public EventScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public EventScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public EventScope WithReturnType(string returnType)
        {
            _returnType = returnType;

            return this;
        }

        public override void Dispose()
        {

        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();

            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetEventStyledSyntax(StyledValue, _returnType, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }
    }
}