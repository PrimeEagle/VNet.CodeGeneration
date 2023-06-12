using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class FieldScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal FieldScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
        //private readonly List<string> _codeLines;
        //private readonly string _type;
        //private readonly string _name;
        //private readonly AccessModifier _modifier;
        //private readonly bool _isStatic;

        //public FieldScope(string type, string name, AccessModifier modifier, bool isStatic, IProgrammingLanguageSettings languageSettings)
        //    : base( languageSettings)
        //{
        //    _type = type;
        //    _name = name;
        //    _modifier = modifier;
        //    _isStatic = isStatic;
        //}

        //protected override string GenerateOpenScope()
        //{
        //    string staticModifier = _isStatic ? LanguageSettings.Syntax.StaticKeyword + " " : string.Empty;
        //    return $"{LanguageSettings.Syntax.GetAccessModifier(_modifier)} {staticModifier}{_type} {_name}";
        //}

        //protected override string GenerateCloseScope()
        //{
        //    return string.Empty;
        //    // Field scope does not require a closing scope
        //}
    }
}