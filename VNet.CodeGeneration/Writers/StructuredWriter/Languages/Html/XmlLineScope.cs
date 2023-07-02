using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public abstract class XmlLineScope<T> : LineScope where T : XmlLineScope<T>
    {
        protected XmlLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}