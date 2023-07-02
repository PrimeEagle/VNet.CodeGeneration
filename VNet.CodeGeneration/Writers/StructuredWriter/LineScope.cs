using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public abstract class LineScope : Scope
    {
        protected LineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        internal override void GenerateCode()
        {
            var cr = new CodeResult();

            WriteCode(cr);
            ProcessCodeResult(cr, false);
        }
    }
}