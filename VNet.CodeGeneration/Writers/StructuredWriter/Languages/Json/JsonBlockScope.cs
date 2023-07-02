using System.Collections.Generic;
using VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common;


namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public abstract class JsonBlockScope<T> : BlockScope where T : JsonBlockScope<T>
    {

        protected JsonBlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
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

        #region JSON language methods
        #endregion JSON language methods
    }
}