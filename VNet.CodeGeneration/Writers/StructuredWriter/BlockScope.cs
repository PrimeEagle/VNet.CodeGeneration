using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public abstract class BlockScope : Scope
    {
        protected BlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        internal override void GenerateCode()
        {
            var cr = new CodeResult();

            WriteCode(cr);
            ProcessCodeResult(cr, true);
        }

        public T UpTo<T>() where T : Scope
        {
            return (T)(this.Parent);
        }
    }
}