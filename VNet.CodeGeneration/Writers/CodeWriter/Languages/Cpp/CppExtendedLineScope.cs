using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public abstract class CppExtendedLineScope<T> : LineScope where T : CppExtendedLineScope<T>
    {
        protected CppExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}