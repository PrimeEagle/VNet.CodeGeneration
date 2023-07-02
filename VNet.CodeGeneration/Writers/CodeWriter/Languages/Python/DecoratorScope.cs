using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class DecoratorScope : PythonLineScope<DecoratorScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public DecoratorScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"@{StyledValue}");
        }
    }
}