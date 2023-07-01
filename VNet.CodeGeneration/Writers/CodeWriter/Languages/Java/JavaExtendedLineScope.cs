using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public abstract class JavaExtendedLineScope<T> : LineScope where T : JavaExtendedLineScope<T>
    {
        protected JavaExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}