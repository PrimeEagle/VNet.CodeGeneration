using System.Collections.Generic;
// ReSharper disable NotAccessedField.Local
#pragma warning disable CS0414
#pragma warning disable IDE0052

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class CommentScope : Scope
    {
        private readonly List<string> _codeLines;
        private CommentType _commentType;
        private readonly List<Scope> _scopes;

        internal CommentScope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
            : base(name, parent, languageSettings)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
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

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            return _codeLines;
        }
    }
}