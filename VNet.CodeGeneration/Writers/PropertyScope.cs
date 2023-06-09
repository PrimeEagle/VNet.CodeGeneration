using System;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class PropertyScope : Scope
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;
        private bool _isStatic;
        private AccessModifier _accessModifier;
        private string _propertyName;
        private string _propertyType;
        private string _getter;
        private string _setter;

        public PropertyScope(string propertyName, string propertyType, bool isStatic, AccessModifier modifier, string getter, string setter, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            _stringBuilder = sb;
            _languageSettings = languageSettings;
            _isStatic = isStatic;
            _accessModifier = modifier;
            _propertyName = propertyName;
            _propertyType = propertyType;
            _getter = getter;
            _setter = setter;
        }

        public PropertyScope(string propertyName, string propertyType, StringBuilder sb, ILanguageSettings languageSettings)
            : this(propertyName, propertyType, false, AccessModifier.Public, null, null, sb, languageSettings)
        {
        }

        public PropertyScope WithAttribute(string attributeName, params string[] args)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public PropertyScope WithDocumentationComment(string comment, CommentType commentType)
        {
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        public PropertyScope WithStatic(bool isStatic = true)
        {
            _isStatic = isStatic;
            return this;
        }

        public PropertyScope WithAccessModifier(AccessModifier modifier)
        {
            _accessModifier = modifier;
            return this;
        }

        public PropertyScope WithGetter(string getter)
        {
            _getter = getter;
            return this;
        }

        public PropertyScope WithSetter(string setter)
        {
            _setter = setter;
            return this;
        }

        public PropertyScope WithIndentation()
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

            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_accessModifier)} {staticStr}{_propertyType} {_propertyName} {OpenBrace()}");
            _languageSettings.Style.IndentLevel++;

            if (!string.IsNullOrEmpty(_getter))
            {
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}get {OpenBrace()}");
                _languageSettings.Style.IndentLevel++;
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_getter};");
                _languageSettings.Style.IndentLevel--;
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
            }

            if (!string.IsNullOrEmpty(_setter))
            {
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}set {OpenBrace()}");
                _languageSettings.Style.IndentLevel++;
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_setter};");
                _languageSettings.Style.IndentLevel--;
                _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
            }

            base.Dispose(disposing);

            _languageSettings.Style.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
        }
    }
}