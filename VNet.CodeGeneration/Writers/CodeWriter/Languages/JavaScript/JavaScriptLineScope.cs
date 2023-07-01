using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.JavaScript
{
    public abstract class JavaScriptLineScope<T> : LineScope where T : JavaScriptLineScope<T>
    {
        protected JavaScriptLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }
    }
}