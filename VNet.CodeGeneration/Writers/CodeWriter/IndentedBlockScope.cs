using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class IndentedBlockScope : BlockScope
    {
        protected IndentedBlockScope() : base()
        {
        }

        protected IndentedBlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        internal override void GenerateCode()
        {
            var cr = new CodeResult();
            GetOpenScope(cr);
            WriteCodeLines(cr);
            GetCloseScope(cr);

            ProcessCodeResult(cr, true);
        }

        protected void IncreaseIndent()
        {
            IndentLevel.Increase();
        }

        protected void DecreaseIndent()
        {
            IndentLevel.Decrease();
        }
    }
}