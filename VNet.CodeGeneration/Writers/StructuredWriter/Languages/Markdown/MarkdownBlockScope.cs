using System.Collections.Generic;
using VNet.CodeGeneration.Writers;
using VNet.CodeGeneration.Writers.StructuredWriter;
using VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common;
using VNet.CodeGeneration.Writers.StructuredWriter.Languages.Markdown;

// ReSharper disable EmptyRegion


namespace VNet.Scientific.CodeGen.Writers.StructuredWriter.Languages.Markdown
{
    public abstract class MarkdownBlockScope<T> : BlockScope where T : MarkdownBlockScope<T>
    {
        protected MarkdownBlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }


        #region Common language methods
        public T AddBlankLine()
        {
            var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return (T)this;
        }

        public T AddBlankLines(int num)
        {
            for (var i = 0; i < num; i++)
            {
                var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
                AddNestedScope(result);
            }

            return (T)this;
        }

        public T AddHeading(string value, int headingLevel)
        {
            var result = new HeadingScope(value, new List<object>() { headingLevel}, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return (T)this;
        }

        #endregion Common language methods

        #region Markdown language methods
        #endregion Markdown language methods
    }
}