using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class CommentScope : Scope
    {
        private readonly List<string> _codeLines;
        private readonly string _comment;
        private readonly CommentType _commentType;
        private readonly List<Scope> _scopes;

        internal CommentScope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
            : base(name, parent, languageSettings)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
    }
}