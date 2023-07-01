using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class StructScope : PowerShellBlockScope<StructScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.StructCaseConversionStyle;


        private List<string> _modifiers;

        public StructScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public MethodScope AddMethod()
        {
            return AddMethod(string.Empty);
        }

        public MethodScope AddMethod(string text)
        {
            var result = new MethodScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public EnumScope AddEnum(string text)
        {
            var result = new EnumScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public PropertyScope AddProperty(string text)
        {
            var result = new PropertyScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StructScope AddStruct(string text)
        {
            var result = new StructScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StructScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        { 
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}struct {StyledValue}");
        }
    }
}