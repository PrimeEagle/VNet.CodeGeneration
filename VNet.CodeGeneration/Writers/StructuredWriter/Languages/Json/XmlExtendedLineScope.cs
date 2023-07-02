using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public abstract class XmlExtendedLineScope<T> : LineScope where T : XmlExtendedLineScope<T>
    {
        protected XmlExtendedLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}