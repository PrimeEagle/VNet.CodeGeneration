using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class PropertySignatureScope : CSharpBlockScope<PropertyScope>
    {
        private string _returnType;
        private List<string> _modifiers;


        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.AccessorCaseConversionStyle;


        public PropertySignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public PropertySignatureScope AddGetterSignature()
        {
            var result = new GetterSignatureScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public PropertySignatureScope AddSetterSignature()
        {
            var result = new SetterSignatureScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {     
            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";
            if (string.IsNullOrEmpty(_returnType)) _returnType = "void";

            result.PreOpenScopeLines.Add($"{modifiers}{_returnType} {StyledValue}");
        }
    }
}