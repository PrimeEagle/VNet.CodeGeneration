using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable MemberCanBePrivate.Global
#pragma warning disable CS0414

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class CommentScope : Scope
    {
        private readonly List<string> _codeLines;
        private CommentType _commentType;
        private readonly List<Scope> _scopes;

        internal CommentScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public CommentScope ThatIsSingleLine()
        {
            _commentType = CommentType.SingleLine;

            return this;
        }

        public CommentScope ThatIsMultiline()
        {
            _commentType = CommentType.MultiLine;

            return this;
        }

        public CommentScope ThatIsDocumentation()
        {
            _commentType = CommentType.Documentation;

            return this;
        }

        protected override string GetStyledValue()
        {
            return Value;
        }

        public CommentScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public CommentScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public CommentScope WithAccessModifier(string accessModifier)
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
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetCommentStyledSyntax(StyledValue, Modifiers, IndentLevel, _commentType));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
    }
}