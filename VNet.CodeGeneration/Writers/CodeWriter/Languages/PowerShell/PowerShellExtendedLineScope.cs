using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public abstract class PowerShellExtendedLineScope<T> : LineScope where T : PowerShellExtendedLineScope<T>
    {
        protected PowerShellExtendedLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}