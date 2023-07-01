using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.TypeScript
{
    public class CommentDocumentationScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => "/**";
        protected override string AlternateScopeCloseSymbol => "*/";


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
                result.PreviousCodeLineSuffix = $"*{spComment}{StyledValue}";
            }

            if (style == ScopeStyle.NewLine)
            {
                var member = new CommentMultiLineMemberScope(Value, null, LanguageSettings, this, IndentLevel, CodeLines);
                Scopes.Insert(0, member);
            }
        }
    }
}