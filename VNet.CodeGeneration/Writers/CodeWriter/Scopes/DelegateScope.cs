using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class DelegateScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal DelegateScope(string name, Scope parent)
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
        //private string _delegateName;
        //private string _returnType;
        //private (string Type, string Name)[] _parameters;

        //public DelegateScope(string delegateName, string returnType, AccessModifier modifier, (string Type, string Name)[] parameters, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _accessModifier = modifier;
        //    _delegateName = delegateName;
        //    _returnType = returnType;
        //    _parameters = parameters ?? new (string Type, string Name)[0];
        //}

        //public DelegateScope(string delegateName, string returnType, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
        //    : this(delegateName, returnType, AccessModifier.Public, null, sb, languageSettings)
        //{
        //}

        //public DelegateScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public DelegateScope WithParameters(params (string Type, string Name)[] parameters)
        //{
        //    _parameters = parameters;
        //    return this;
        //}

        //public override void GenerateCode()
        //{
        //    _stringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Syntax.GetAccessModifier(_accessModifier)} delegate {_returnType} {_delegateName}({GetParameters()});");
        //}

        //private string GetParameters()
        //{
        //    return string.Join(", ", _parameters.Select(p => $"{p.Type} {p.Name}"));
        //}
    }
}