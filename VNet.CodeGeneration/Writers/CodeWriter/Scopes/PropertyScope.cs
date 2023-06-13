using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class PropertyScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal PropertyScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        public PropertyScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public PropertyScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public PropertyScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
        //private readonly List<string> _codeLines;
        //private bool _isStatic;
        //private AccessModifier _accessModifier;
        //private string _propertyName;
        //private string _propertyType;
        //private MethodScope _getter;
        //private MethodScope _setter;

        //public PropertyScope(string propertyName, string propertyType, bool isStatic, AccessModifier modifier, MethodScope getter, MethodScope setter, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _isStatic = isStatic;
        //    _accessModifier = modifier;
        //    _propertyName = propertyName;
        //    _propertyType = propertyType;
        //    _getter = getter;
        //    _setter = setter;
        //}

        //public PropertyScope(string propertyName, string propertyType, IProgrammingLanguageSettings languageSettings)
        //    : this(propertyName, propertyType, false, AccessModifier.Public, null, null, languageSettings)
        //{
        //}

        //public PropertyScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public PropertyScope WithStatic(bool isStatic = true)
        //{
        //    _isStatic = isStatic;
        //    return this;
        //}

        //public PropertyScope WithGetter(MethodScope getter)
        //{
        //    _getter = getter;
        //    return this;
        //}

        //public PropertyScope WithSetter(MethodScope setter)
        //{
        //    _setter = setter;
        //    return this;
        //}

        //public override void GenerateCode()
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.GetAccessModifier(_accessModifier)} " +
        //                              $"{(_isStatic ? LanguageSettings.Syntax.StaticKeyword + " " : string.Empty)}{_propertyType} {_propertyName}");

        //    _stringBuilder.AppendLine(LanguageSettings.Style.OpenScope);

        //    if (_getter != null)
        //    {
        //        _getter.GenerateCode();
        //    }

        //    if (_setter != null)
        //    {
        //        _setter.GenerateCode();
        //    }

        //    _stringBuilder.AppendLine(LanguageSettings.Style.CloseScope);
        //}
    }
    //public sealed class PropertyScope : Scope
    //{
    //    private readonly List<string> _codeLines;
    //    private readonly IProgrammingLanguageSettings _languageSettings;
    //    private bool _isStatic;
    //    private AccessModifier _accessModifier;
    //    private string _propertyName;
    //    private string _propertyType;
    //    private string _getter;
    //    private string _setter;

    //    public PropertyScope(string propertyName, string propertyType, bool isStatic, AccessModifier modifier, string getter, string setter, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
    //        : base(sb, languageSettings)
    //    {
    //        _stringBuilder = sb;
    //        _languageSettings = languageSettings;
    //        _isStatic = isStatic;
    //        _accessModifier = modifier;
    //        _propertyName = propertyName;
    //        _propertyType = propertyType;
    //        _getter = getter;
    //        _setter = setter;
    //    }

    //    public PropertyScope(string propertyName, string propertyType, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
    //        : this(propertyName, propertyType, false, AccessModifier.Public, null, null, sb, languageSettings)
    //    {
    //    }

    //    public PropertyScope WithAttribute(string attributeName, params string[] args)
    //    {
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
    //        return this;
    //    }

    //    public PropertyScope WithDocumentationComment(string comment, CommentType commentType)
    //    {
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
    //        return this;
    //    }

    //    public PropertyScope WithStatic(bool isStatic = true)
    //    {
    //        _isStatic = isStatic;
    //        return this;
    //    }

    //    public PropertyScope WithAccessModifier(AccessModifier modifier)
    //    {
    //        _accessModifier = modifier;
    //        return this;
    //    }

    //    public PropertyScope WithGetter(string getter)
    //    {
    //        _getter = getter;
    //        return this;
    //    }

    //    public PropertyScope WithSetter(string setter)
    //    {
    //        _setter = setter;
    //        return this;
    //    }

    //    public PropertyScope WithIndentation()
    //    {
    //        _languageSettings.Style.IndentLevel++;
    //        return this;
    //    }

    //    private string OpenBrace()
    //    {
    //        return _languageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + _languageSettings.Style.OpenScope : _languageSettings.Style.LineBreakCharacter + _languageSettings.Style.GetIndent() + _languageSettings.Style.OpenScope;
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        var staticStr = _isStatic ? _languageSettings.Keywords.StaticKeyword + " " : string.Empty;

    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_accessModifier)} {staticStr}{_propertyType} {_propertyName} {OpenBrace()}");
    //        _languageSettings.Style.IndentLevel++;

    //        if (!string.IsNullOrEmpty(_getter))
    //        {
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}get {OpenBrace()}");
    //            _languageSettings.Style.IndentLevel++;
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_getter};");
    //            _languageSettings.Style.IndentLevel--;
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
    //        }

    //        if (!string.IsNullOrEmpty(_setter))
    //        {
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}set {OpenBrace()}");
    //            _languageSettings.Style.IndentLevel++;
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_setter};");
    //            _languageSettings.Style.IndentLevel--;
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
    //        }

    //        base.Dispose(disposing);

    //        _languageSettings.Style.IndentLevel--;
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
    //    }
    //}
}