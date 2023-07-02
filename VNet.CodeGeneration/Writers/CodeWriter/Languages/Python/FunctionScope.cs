using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class FunctionScope : PythonBlockScope<FunctionScope>
    {
        private List<string> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;


        public FunctionScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _parameters = new List<string>();
        }

        public FunctionScope WithParameter(string name)
        {
            _parameters.Add(name);

            return this;
        }

        public FunctionScope ThatIsAConstructor()
        {
            Value = "__init__";
            _parameters.Insert(0, "self");

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var paramStr = string.Join($",{spComma}", _parameters).Trim();

            result.PreOpenScopeLines.Add($"def {StyledValue}({paramStr})");
        }
    }
}