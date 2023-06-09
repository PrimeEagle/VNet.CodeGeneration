using System.Linq;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class MethodScope : Scope
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;
        private bool _isStatic;
        private AccessModifier _accessModifier;
        private string _methodName;
        private string _returnType;
        private (string Type, string Name)[] _parameters;

        public MethodScope(string methodName, string returnType, bool isStatic, AccessModifier modifier, (string Type, string Name)[] parameters, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            _stringBuilder = sb;
            _languageSettings = languageSettings;
            _isStatic = isStatic;
            _accessModifier = modifier;
            _methodName = methodName;
            _returnType = returnType;
            _parameters = parameters;
        }

        public MethodScope(string methodName, string returnType, StringBuilder sb, ILanguageSettings languageSettings)
            : this(methodName, returnType, false, AccessModifier.Public, new (string Type, string Name)[0], sb, languageSettings)
        {
        }

        public MethodScope WithAttribute(string attributeName, params string[] args)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public MethodScope WithDocumentationComment(string comment, CommentType commentType)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        public MethodScope WithStatic(bool isStatic = true)
        {
            _isStatic = isStatic;
            return this;
        }

        public MethodScope WithAccessModifier(AccessModifier modifier)
        {
            _accessModifier = modifier;
            return this;
        }

        public MethodScope WithParameters(params (string Type, string Name)[] parameters)
        {
            _parameters = parameters;
            return this;
        }

        public MethodScope WithReturnType(string returnType)
        {
            _returnType = returnType;
            return this;
        }

        public MethodScope WithIndentation()
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
            var staticStr = _isStatic ? _languageSettings.Keywords.StaticKeyword + " " : string.Empty;
            var parametersList = string.Join(", ", _parameters.Select(p => $"{p.Type} {p.Name}"));

            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_accessModifier)} {staticStr}{_returnType} {_methodName}({parametersList}) {OpenBrace()}");
            _languageSettings.Style.IndentLevel++;

            base.Dispose(disposing);

            _languageSettings.Style.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
        }
    }
}