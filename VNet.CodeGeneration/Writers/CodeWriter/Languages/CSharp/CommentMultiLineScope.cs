using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CommentMultiLineScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CommentMultiLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        public CommentMultiLineScope AddBlankLine()
        {
            var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CommentMultiLineScope AddBlankLines(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
                AddNestedScope(result);
            }

            return this;
        }

        public CommentMultiLineScope AddCodeLine(string text)
        {
            var result = new CodeLineScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CodeBlockScope AddCodeBlock(string text)
        {
            var result = new CodeBlockScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCodeLines()
        {
            return;
        }
    }
}