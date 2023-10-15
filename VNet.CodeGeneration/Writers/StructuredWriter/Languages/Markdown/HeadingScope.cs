using System.Collections.Generic;
using System.Text;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Markdown
{
    public class HeadingScope : MarkdownLineScope<HeadingScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.CommentCaseConversionStyle;

        public HeadingScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }    

        protected override void WriteCode(CodeResult result)
        {
            var numLevels = 1;
            var prefix = new StringBuilder();

            for (var i = 0; i < numLevels; i++)
            {
                prefix.Append("#");
            }
            prefix.Append(" ");
            result.UnscopedCodeLines.Add($"{prefix}{StyledValue}");
        }
    }
}