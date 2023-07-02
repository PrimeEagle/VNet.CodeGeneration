using System.Collections.Generic;
using VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common;


namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public abstract class HtmlBlockScope<T> : BlockScope where T : HtmlBlockScope<T>
    {

        protected HtmlBlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
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
            for (int i = 0; i < num; i++)
            {
                var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
                AddNestedScope(result);
            }

            return (T)this;
        }
        #endregion Common language methods

        #region HTML language methods
        public CommentScope AddComment(string name)
        {
            var result = new CommentScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddHeader1(string name)
        {
            var result = new StandardElementScope("h1", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddHeader2(string name)
        {
            var result = new StandardElementScope("h2", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddHeader3(string name)
        {
            var result = new StandardElementScope("h3", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddHeader4(string name)
        {
            var result = new StandardElementScope("h4", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddParagraph(string name)
        {
            var result = new StandardElementScope("p", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StandardElementScope AddDiv(string name)
        {
            var result = new StandardElementScope("div", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public AnchorElementScope AddAnchor(string name)
        {
            var result = new AnchorElementScope("div", null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }
        #endregion HTML language methods
    }
}