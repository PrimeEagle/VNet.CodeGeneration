using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class UsingScope : PythonLineScope<UsingScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ImportCaseConversionStyle;


        internal UsingScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"using {StyledValue};");
        }
    }
}