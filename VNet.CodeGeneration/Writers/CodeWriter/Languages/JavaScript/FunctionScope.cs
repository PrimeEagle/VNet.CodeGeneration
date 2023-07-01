using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.JavaScript
{
    public class FunctionScope : JavaScriptBlockScope<FunctionScope>
    {
        private List<string> _modifiers;
        private List<string> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;


        public FunctionScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _parameters = new List<string>();
        }

        public FunctionScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public FunctionScope WithParameter( string name)
        {
            _parameters.Add(name);

            return this;
        }

        public FunctionScope ThatIsAConstructor()
        {
            Value = "constructor";

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var paramStr = string.Join($",{spComma}", _parameters).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}function {StyledValue}({paramStr})");
        }
    }
}