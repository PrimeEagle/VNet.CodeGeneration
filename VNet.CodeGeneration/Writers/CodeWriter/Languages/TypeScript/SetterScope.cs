using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class SetterScope : TypeScriptExtendedLineScope<SetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.SetterCaseConversionStyle;


        private List<string> _modifiers;
        private string _parameterName;
        private string _parameterType;


        public SetterScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public SetterScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public SetterScope WithParameter(string name, string type)
        {
            _parameterName = name;
            _parameterType = type;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var param = !string.IsNullOrEmpty(_parameterName) ? _parameterName : string.Empty;
            if (!string.IsNullOrEmpty(param) && !string.IsNullOrEmpty(_parameterType))
            {
                param += $": {_parameterType}";
            }

            result.PreOpenScopeLines.Add($"set {modifiers}set{StyledValue}({param})");
        }
    }
}