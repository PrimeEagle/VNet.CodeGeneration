using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Common
{
    public class CodeBlockScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CodeBlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCodeLines()
        {
            return;
        }
    }
}