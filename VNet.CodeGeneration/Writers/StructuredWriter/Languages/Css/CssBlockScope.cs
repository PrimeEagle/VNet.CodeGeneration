using System.Collections.Generic;
using VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common;


namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public abstract class CssBlockScope<T> : BlockScope where T : CssBlockScope<T>
    {

        protected CssBlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
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

        #region XML language methods
        #endregion XML language methods
    }
}