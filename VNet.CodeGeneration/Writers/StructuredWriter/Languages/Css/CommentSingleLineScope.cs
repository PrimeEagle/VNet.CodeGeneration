using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class CommentSingleLineScope : CssLineScope<CommentSingleLineScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CommentSingleLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"/*{SpComment}{StyledValue}{SpComment}*/");
        }
    }
}