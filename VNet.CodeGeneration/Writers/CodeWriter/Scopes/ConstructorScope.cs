using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ConstructorScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal ConstructorScope(string name, Scope parent)
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
        //private readonly IProgrammingLanguageSettings _languageSettings;
        //private string _className;
        //private (string Type, string Name)[] _parameters;

        //public ConstructorScope(string className, (string Type, string Name)[] parameters, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _languageSettings = languageSettings;
        //    _className = className;
        //    _parameters = parameters;
        //}

        //public ConstructorScope WithAttribute(string attributeName, params string[] args)
        //{
        //    _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}[{_languageSettings.Syntax.GetAttributeSyntax(attributeName, args)}]");
        //    return this;
        //}

        //public ConstructorScope WithDocumentationComment(string comment, CommentType commentType)
        //{
        //    _stringBuilder.AppendLine($"{_languageSettings.Style.GetIndent()}{_languageSettings.Syntax.GetCommentSyntax(comment, commentType)}");
        //    return this;
        //}

        //public ConstructorScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _stringBuilder.Append($"{_languageSettings.Style.GetIndent()}{_languageSettings.Syntax.GetAccessModifier(modifier)}");
        //    return this;
        //}

        //public ConstructorScope WithParameters(params (string Type, string Name)[] parameters)
        //{
        //    _parameters = parameters;
        //    return this;
        //}

        //public ConstructorScope WithIndentation()
        //{
        //    _languageSettings.Style.IndentLevel++;
        //    return this;
        //}

        //private string FormatParameters()
        //{
        //    var parameterList = string.Join(", ", _parameters.Select(p => $"{p.Type} {p.Name}"));
        //    return $"({parameterList})";
        //}

        //private string OpenBrace()
        //{
        //    return _languageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + _languageSettings.Style.OpenScope : _languageSettings.Style.LineBreakCharacter + _languageSettings.Style.GetIndent() + _languageSettings.Style.OpenScope;
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    LanguageSettings.Style.IndentLevel--;
        //    StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{GenerateCloseScope()}");
        //}
    }
}