using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class BlockScope : Scope
    {
        protected BlockScope() : base()
        {

        }

        protected BlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {

        }

        internal override void GenerateCode()
        {
            var cr = new CodeResult();

            GetOpenScope(cr);
            WriteCodeLines(cr);
            GetCloseScope(cr);

            ProcessCodeResult(cr);
        }
    }
}