using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class CommentDocumentationScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => $"///{spComment}<summary>";
        protected override string AlternateScopeCloseSymbol => $"///{spComment}</summary>";


        public CommentDocumentationScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public CommentDocumentationScope AddComment(string name)
        {
            var result = new CommentDocumentationMemberScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var style = LanguageSettings.Style.MultilineCommentStyle;

            if (style == ScopeStyle.SameLine)
            {
                result.PreviousCodeLineSuffix = $"///{spComment}{StyledValue}";
            }

            if (style == ScopeStyle.NewLine)
            {
                var member = new CommentMultiLineMemberScope(Value, null, LanguageSettings, this, IndentLevel, CodeLines);
                Scopes.Insert(0, member);
            }
        }
    }
}