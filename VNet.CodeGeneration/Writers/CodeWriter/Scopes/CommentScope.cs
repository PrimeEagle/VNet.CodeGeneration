using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
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