using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class EnumScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal EnumScope(string name, Scope parent)
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
        //private AccessModifier _accessModifier;
        //private string _enumName;
        //private EnumMember[] _members;

        //public EnumScope(string enumName, AccessModifier modifier, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _accessModifier = modifier;
        //    _enumName = enumName;
        //    _members = new EnumMember[0];
        //}

        //public EnumScope(string enumName, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
        //    : this(enumName, AccessModifier.Public, languageSettings)
        //{
        //}

        //public EnumScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public EnumScope WithMembers(params EnumMember[] members)
        //{
        //    _members = members;
        //    return this;
        //}

        //public override void GenerateCode()
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.GetAccessModifier(_accessModifier)} enum {_enumName} {GenerateOpenScope()}");
        //    LanguageSettings.Style.IndentLevel++;

        //    foreach (var member in _members)
        //    {
        //        _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{member.Name}{LanguageSettings.Syntax.EnumSeparatorCharacter}{member.Value},");
        //    }

        //    LanguageSettings.Style.IndentLevel--;
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Style.CloseScope}");
        //}
    }
}