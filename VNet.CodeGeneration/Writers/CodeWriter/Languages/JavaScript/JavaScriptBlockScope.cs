using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public abstract class JavaScriptBlockScope<T> : BlockScope where T : JavaScriptBlockScope<T>
    {

        protected JavaScriptBlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }


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

        public T AddCodeLine(string text)
        {
            var result = new CodeLineScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return (T)this;
        }

        public T AddCodeBlock(string text)
        {
            var result = new CodeBlockScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return (T)this;
        }

        public CustomScope AddScope()
        {
            var result = new CustomScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }
        #endregion Common language methods

        #region JavaScript language methods
       
        public T AddSingleLineComment(string name)
        {
            var result = new CommentSingleLineScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return (T)this;
        }

        public CommentMultiLineScope AddMultiLineComment(string name)
        {
            var result = new CommentMultiLineScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CommentDocumentationScope AddDocumentationComment(string name)
        {
            var result = new CommentDocumentationScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }
        #endregion C# language methods
    }
}