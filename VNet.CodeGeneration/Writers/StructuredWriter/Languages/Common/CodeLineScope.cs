using System.Collections.Generic;
using VNet.CodeGeneration.Writers.StructuredWriter;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common
{
    public class CodeLineScope : LineScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CodeLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"{StyledValue}");
        }
    }
}