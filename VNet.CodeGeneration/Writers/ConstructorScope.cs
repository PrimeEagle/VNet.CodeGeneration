using System.Linq;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class ConstructorScope : Scope
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;
        private AccessModifier _accessModifier;
        private string _className;
        private (string type, string name)[] _parameters;

        public ConstructorScope(string className, (string type, string name)[] parameters, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            _stringBuilder = sb;
            _languageSettings = languageSettings;
            _accessModifier = AccessModifier.Public;
            _className = className;
            _parameters = parameters;
        }

        public ConstructorScope WithAttribute(string attributeName, params string[] args)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public ConstructorScope WithDocumentationComment(string comment, CommentType commentType)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        public ConstructorScope WithAccessModifier(AccessModifier modifier)
        {
            _accessModifier = modifier;
            return this;
        }

        public ConstructorScope WithIndentation()
        {
            _languageSettings.Style.IndentLevel++;
            return this;
        }

        private string OpenBrace()
        {
            return _languageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + _languageSettings.Style.OpenScope : _languageSettings.Style.LineBreakCharacter + _languageSettings.Style.GetIndent() + _languageSettings.Style.OpenScope;
        }

        protected override void Dispose(bool disposing)
        {
            var paramsList = string.Join(", ", _parameters.Select(p => $"{p.type} {p.name}"));

            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_accessModifier)} {_className}({paramsList}){OpenBrace()}");
            _languageSettings.Style.IndentLevel++;

            base.Dispose(disposing);

            _languageSettings.Style.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
        }
    }
}