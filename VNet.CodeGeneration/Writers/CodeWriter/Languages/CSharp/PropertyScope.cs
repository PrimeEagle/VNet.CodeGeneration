using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class PropertyScope : CSharpBlockScope<PropertyScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.AccessorCaseConversionStyle;


        public PropertyScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}