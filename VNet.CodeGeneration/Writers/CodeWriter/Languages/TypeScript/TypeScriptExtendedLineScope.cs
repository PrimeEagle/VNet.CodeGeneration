using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public abstract class TypeScriptExtendedLineScope<T> : LineScope where T : TypeScriptExtendedLineScope<T>
    {
        protected TypeScriptExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}