using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class ClassScope : Scope
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;
        private bool _isStatic;
        private AccessModifier _modifier;
        private string _className;

        public ClassScope(string className, bool isStatic, AccessModifier modifier, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            _stringBuilder = sb;
            _languageSettings = languageSettings;
            _isStatic = isStatic;
            _modifier = modifier;
            _className = className;
        }

        public ClassScope(string className, StringBuilder sb, ILanguageSettings languageSettings)
            : this(className, false, AccessModifier.Public, sb, languageSettings)
        {
        }

        public PropertyScope WithProperty(string propertyName, string propertyType)
        {
            var propertyScope = new PropertyScope(propertyName, propertyType, _isStatic, _modifier, null, null, _stringBuilder, _languageSettings);
            return propertyScope;
        }

        public MethodScope WithMethod(string methodName, string returnType, params (string Type, string Name)[] parameters)
        {
            var methodScope = new MethodScope(methodName, returnType, false, _modifier, parameters, _stringBuilder, _languageSettings);
            return methodScope;
        }

        public ConstructorScope WithConstructor(params (string Type, string Name)[] parameters)
        {
            var constructorScope = new ConstructorScope(_className, parameters, _stringBuilder, _languageSettings);
            return constructorScope;
        }

        public ClassScope WithAttribute(string attributeName, params string[] args)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public ClassScope WithDocumentationComment(string comment, CommentType commentType)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        public ClassScope WithStatic(bool isStatic = true)
        {
            _isStatic = isStatic;
            return this;
        }

        public ClassScope WithAccessModifier(AccessModifier modifier)
        {
            _modifier = modifier;
            return this;
        }

        public ClassScope WithIndentation()
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

            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_modifier)} {staticStr}{_className} {OpenBrace()}");
            _languageSettings.Style.IndentLevel++;

            base.Dispose(disposing);

            _languageSettings.Style.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
        }
    }
}