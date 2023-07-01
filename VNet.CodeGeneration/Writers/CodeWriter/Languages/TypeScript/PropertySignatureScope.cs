using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.TypeScript
{
    public class PropertySignatureScope : TypeScriptBlockScope<PropertySignatureScope>
    {
        private string _returnType;
        private List<string> _modifiers;


        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.AccessorCaseConversionStyle;


        public PropertySignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public PropertySignatureScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public PropertySignatureScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {       
            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";
                       
            result.PreOpenScopeLines.Add($"{modifiers}{StyledValue}: {_returnType};");
        }
    }
}