using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public abstract class TypeScriptLineScope<T> : LineScope where T : TypeScriptLineScope<T>
    {
        protected TypeScriptLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }
    }
}