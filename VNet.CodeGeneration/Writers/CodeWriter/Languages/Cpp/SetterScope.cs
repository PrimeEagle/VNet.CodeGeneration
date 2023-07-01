using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class SetterScope : CppBlockScope<SetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.SetterCaseConversionStyle;


        private List<string> _modifiers;


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

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"set");
        }
    }
}