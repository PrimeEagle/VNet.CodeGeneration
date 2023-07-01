using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class CommentSingleLineScope : JavaScriptLineScope<CommentSingleLineScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CommentSingleLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"//{spComment}{StyledValue}");
        }
    }
}