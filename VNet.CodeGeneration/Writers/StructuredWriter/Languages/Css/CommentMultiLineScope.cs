using System.Collections.Generic;


namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class CommentMultiLineScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => "/*";
        protected override string AlternateCloseScopeCloseSymbol => "*/";

        public CommentMultiLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        public CommentMultiLineScope AddComment(string name)
        {
            var result = new CommentMultiLineMemberScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
        }
    }
}