using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public abstract class JavaScriptExtendedLineScope<T> : LineScope where T : JavaScriptExtendedLineScope<T>
    {
        protected JavaScriptExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}