using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public abstract class CSharpLineScope<T> : LineScope where T : CSharpLineScope<T>
    {
        protected CSharpLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}