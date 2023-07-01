using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class SetterScope : JavaScriptBlockScope<SetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.SetterCaseConversionStyle;


        private List<string> _modifiers;
        private List<string> _parameters;


        public SetterScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _parameters = new List<string>();
        }

        public SetterScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public SetterScope WithParameter(string name)
        {
            _parameters.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var paramStr = string.Join($",{spComma}", _parameters).Trim();

            result.PreOpenScopeLines.Add($"set {modifiers}set{StyledValue}({paramStr})");
        }
    }
}