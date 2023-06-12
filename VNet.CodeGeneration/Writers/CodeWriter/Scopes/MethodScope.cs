using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class MethodScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal MethodScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
        //private readonly List<string> _codeLines;
        //private bool _isStatic;
        //private AccessModifier _accessModifier;
        //private string _methodName;
        //private string _returnType;
        //private (string Type, string Name)[] _parameters;

        //public MethodScope(string methodName, string returnType, bool isStatic, AccessModifier modifier, (string Type, string Name)[] parameters, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _isStatic = isStatic;
        //    _accessModifier = modifier;
        //    _methodName = methodName;
        //    _returnType = returnType;
        //    _parameters = parameters ?? new (string Type, string Name)[0];
        //}

        //public MethodScope(string methodName, string returnType, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
        //    : this(methodName, returnType, false, AccessModifier.Public, null, languageSettings)
        //{
        //}

        //public MethodScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public MethodScope WithStatic(bool isStatic = true)
        //{
        //    _isStatic = isStatic;
        //    return this;
        //}

        //public MethodScope WithParameter(string parameterType, string parameterName)
        //{
        //    var parameter = (parameterType, parameterName);
        //    _parameters = _parameters.Concat(new[] { parameter }).ToArray();
        //    return this;
        //}

        //public override void GenerateCode()
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.GetAccessModifier(_accessModifier)} " +
        //                              $"{(_isStatic ? LanguageSettings.Syntax.StaticKeyword + " " : string.Empty)}{_returnType} {_methodName}({GetParameters()})" +
        //                              $"{LanguageSettings.Style.OpenScope}");

        //    base.GenerateCode();

        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Style.CloseScope}");
        //}

        //private string GetParameters()
        //{
        //    return string.Join(", ", _parameters.Select(p => $"{p.Type} {p.Name}"));
        //}
    }
    //public sealed class MethodScope : Scope
    //{
    //    private readonly List<string> _codeLines;
    //    private readonly IProgrammingLanguageSettings _languageSettings;
    //    private bool _isStatic;
    //    private AccessModifier _accessModifier;
    //    private string _methodName;
    //    private string _returnType;
    //    private (string Type, string Name)[] _parameters;
    //    private string _methodBody;

    //    // Updated constructor with a methodBody parameter
    //    public MethodScope(string methodName, string returnType, bool isStatic, AccessModifier modifier, (string Type, string Name)[] parameters, StringBuilder sb, IProgrammingLanguageSettings languageSettings, string methodBody = null)
    //        : base(sb, languageSettings)
    //    {
    //        _stringBuilder = sb;
    //        _languageSettings = languageSettings;
    //        _isStatic = isStatic;
    //        _accessModifier = modifier;
    //        _methodName = methodName;
    //        _returnType = returnType;
    //        _parameters = parameters;
    //        _methodBody = methodBody;
    //    }

    //    public MethodScope(string methodName, string returnType, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
    //        : this(methodName, returnType, false, AccessModifier.Public, new (string Type, string Name)[0], sb, languageSettings)
    //    {
    //    }

    //    public MethodScope WithAttribute(string attributeName, params string[] args)
    //    {
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
    //        return this;
    //    }

    //    public MethodScope WithDocumentationComment(string comment, CommentType commentType)
    //    {
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
    //        return this;
    //    }

    //    public MethodScope WithStatic(bool isStatic = true)
    //    {
    //        _isStatic = isStatic;
    //        return this;
    //    }

    //    public MethodScope WithAccessModifier(AccessModifier modifier)
    //    {
    //        _accessModifier = modifier;
    //        return this;
    //    }

    //    public MethodScope WithParameters(params (string Type, string Name)[] parameters)
    //    {
    //        _parameters = parameters;
    //        return this;
    //    }

    //    public MethodScope WithReturnType(string returnType)
    //    {
    //        _returnType = returnType;
    //        return this;
    //    }

    //    public MethodScope WithIndentation()
    //    {
    //        _languageSettings.Style.IndentLevel++;
    //        return this;
    //    }

    //    private string OpenBrace()
    //    {
    //        return _languageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + _languageSettings.Style.OpenScope : _languageSettings.Style.LineBreakCharacter + _languageSettings.Style.GetIndent() + _languageSettings.Style.OpenScope;
    //    }

    //    public MethodScope WithBody(string methodBody)
    //    {
    //        _methodBody = methodBody;
    //        return this;
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        var staticStr = _isStatic ? _languageSettings.Keywords.StaticKeyword + " " : string.Empty;
    //        var parametersList = string.Join(", ", _parameters.Select(p => $"{p.Type} {p.Name}"));

    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Keywords.GetAccessModifier(_accessModifier)} {staticStr}{_returnType} {_methodName}({parametersList}) {OpenBrace()}");
    //        _languageSettings.Style.IndentLevel++;

    //        // Add method body if it exists
    //        if (!string.IsNullOrWhiteSpace(_methodBody))
    //        {
    //            _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_methodBody}");
    //        }

    //        base.Dispose(disposing);

    //        _languageSettings.Style.IndentLevel--;
    //        _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Style.CloseScope}");
    //    }
    //}
}