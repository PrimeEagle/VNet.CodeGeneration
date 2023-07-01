using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class ExtendedLineScope : LineScope
    {
        protected ExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public T UpTo<T>() where T : Scope
        {
            return (T)(this.Parent);
        }
    }
}