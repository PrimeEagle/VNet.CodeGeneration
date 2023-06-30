using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Common
{
    public class CommentMultiLineMemberScope : CSharpLineScope<CommentMultiLineMemberScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CommentMultiLineMemberScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            var space = LanguageSettings.Style.SpaceAfterCommentCharacter ? " " : string.Empty;

            result.ScopedCodeLines.Add($"*{space}{StyledValue}");
        }
    }
}