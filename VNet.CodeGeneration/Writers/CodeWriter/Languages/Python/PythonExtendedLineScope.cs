using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public abstract class PythonExtendedLineScope<T> : LineScope where T : PythonExtendedLineScope<T>
    {
        protected PythonExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}