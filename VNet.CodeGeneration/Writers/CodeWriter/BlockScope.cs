using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class BlockScope : Scope
    {
        protected BlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {

        }

        internal override void GenerateCode()
        {
            var cr = new CodeResult();

            WriteCode(cr);
            ProcessCodeResult(cr, true);
        }
    }
}