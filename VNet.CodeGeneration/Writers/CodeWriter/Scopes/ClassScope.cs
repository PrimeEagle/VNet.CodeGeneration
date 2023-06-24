using System.Collections.Generic;
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ClassScope : Scope
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private readonly List<string> _genericTypes;
        private readonly List<string> _genericConstraints;
        private readonly List<string> _derivedFrom;
        private readonly List<string> _implements;

        internal ClassScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
            _derivedFrom = new List<string>();
            _implements = new List<string>();
        }

        public ClassScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public ClassScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public ClassScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public ClassScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public ClassScope WithGenericType(string genericType)
        {
            _genericTypes.Add(genericType);

            return this;
        }

        public ClassScope WithGenericConstraint(string genericConstraint)
        {
            _genericConstraints.Add(genericConstraint);

            return this;
        }

        public ClassScope DerivedFrom(string baseClass)
        {
            _derivedFrom.Add(baseClass);

            return this;
        }

        public ClassScope Implementing(string interfaceName)

        {
            _implements.Add(interfaceName);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            ValidateModifiers(Modifiers);

            _codeLines.Clear();
            
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetClassStyledSyntax(StyledValue, _genericTypes, _genericConstraints, _derivedFrom, _implements, Modifiers, IndentLevel));
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current));
            IndentLevel.Increase();

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            Dispose();

            return _codeLines;
        }

        public override void Dispose()
        {
            base.Dispose();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetClassPostScopeStyledSyntax(StyledValue, _genericTypes, _genericConstraints, _derivedFrom, _implements, Modifiers, IndentLevel));
        }
    }
}