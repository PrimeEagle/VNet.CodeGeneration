using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Yaml
{
    public class CommentScope : YamlLineScope<CommentScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.CommentCaseConversionStyle;

        public CommentScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }    

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"#{spComment}{StyledValue}");
        }
    }
}