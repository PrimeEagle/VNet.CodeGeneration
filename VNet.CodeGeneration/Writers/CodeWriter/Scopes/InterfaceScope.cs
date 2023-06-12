using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class InterfaceScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal InterfaceScope(string name, Scope parent)
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
        //private AccessModifier _accessModifier;
        //private string _interfaceName;

        //public InterfaceScope(string interfaceName, AccessModifier modifier, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _accessModifier = modifier;
        //    _interfaceName = interfaceName;
        //}

        //public InterfaceScope(string interfaceName, IProgrammingLanguageSettings languageSettings)
        //    : this(interfaceName, AccessModifier.Public, languageSettings)
        //{
        //}

        //public InterfaceScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public MethodScope WithMethod(string methodName, string returnType, params (string Type, string Name)[] parameters)
        //{
        //    var methodScope = new MethodScope(methodName, returnType, false, AccessModifier.Public, parameters, _stringBuilder, LanguageSettings);
        //    AddNestedScope(methodScope);
        //    return methodScope;
        //}

        //public InterfaceScope WithProperty(string propertyName, string propertyType)
        //{
        //    var propertyScope = new PropertyScope(propertyName, propertyType, false, AccessModifier.Public, null, null, _stringBuilder, LanguageSettings);
        //    AddNestedScope(propertyScope);
        //    return this;
        //}
    }
}