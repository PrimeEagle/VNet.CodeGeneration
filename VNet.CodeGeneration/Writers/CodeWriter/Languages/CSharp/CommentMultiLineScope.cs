using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CommentMultiLineScope : CSharpBlockScope<CommentMultiLineScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => "/*";
        protected override string AlternateScopeCloseSymbol => "*/";

        public CommentMultiLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        public CommentMultiLineMemberScope AddComment(string text)
        {
            var result = new CommentMultiLineMemberScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            var space = LanguageSettings.Style.SpaceAfterCommentCharacter ? " " : string.Empty;

            result.ScopedCodeLines.Add($"*{space}{StyledValue}");
        }
    }
}