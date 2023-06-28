using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class LineScope : Scope
    {
        protected LineScope() : base()
        {
        }

        protected LineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        internal override void GenerateCode()
        {
            WriteCodeLines();
        }
    }
}