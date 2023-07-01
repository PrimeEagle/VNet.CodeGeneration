using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public abstract class CSharpExtendedLineScope<T> : LineScope where T : CSharpExtendedLineScope<T>
    {
        protected CSharpExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}