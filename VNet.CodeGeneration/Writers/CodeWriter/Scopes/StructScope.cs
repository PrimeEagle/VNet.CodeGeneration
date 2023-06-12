using System.Collections.Generic;
using System.Text;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class StructScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal StructScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetStructStyledSyntax(StyledValue, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }
        //private readonly List<string> _codeLines;
        //private AccessModifier _accessModifier;
        //private string _structName;
        //private (string Type, string Name, AccessModifier Modifier)[] _fields;

        //public StructScope(string structName, AccessModifier modifier, IProgrammingLanguageSettings languageSettings, (string Type, string Name, AccessModifier Modifier)[] fields = null)
        //    : base(languageSettings)
        //{
        //    _accessModifier = modifier;
        //    _structName = structName;
        //    _fields = fields ?? new (string Type, string Name, AccessModifier Modifier)[0];
        //}

        //public StructScope(string structName, StringBuilder sb, IProgrammingLanguageSettings languageSettings)
        //    : this(structName, AccessModifier.Public, sb, languageSettings)
        //{
        //}

        //public PropertyScope WithProperty(string propertyName, string propertyType)
        //{
        //    var propertyScope = new PropertyScope(propertyName, propertyType, false, AccessModifier.Public, null, null, LanguageSettings);
        //    AddNestedScope(propertyScope);
        //    return propertyScope;
        //}

        //public MethodScope WithMethod(string methodName, string returnType, params (string Type, string Name)[] parameters)
        //{
        //    var methodScope = new MethodScope(methodName, returnType, false, AccessModifier.Public, parameters, LanguageSettings);
        //    AddNestedScope(methodScope);
        //    return methodScope;
        //}

        //public StructScope WithAccessModifier(AccessModifier modifier)
        //{
        //    _accessModifier = modifier;
        //    return this;
        //}

        //public StructScope WithFields(params (string Type, string Name, AccessModifier Modifier)[] fields)
        //{
        //    _fields = fields;
        //    return this;
        //}
    }
}