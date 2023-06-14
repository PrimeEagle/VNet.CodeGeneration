using System;
using System.Collections.Generic;
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class CodeBlockScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal CodeBlockScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public CodeBlockScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public CodeBlockScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public CodeBlockScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public CodeBlockScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public override void Dispose()
        {

        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            
            var values = StyledValue.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);
            foreach (var value in values)
            {
                _codeLines.Add(value);
            }

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}