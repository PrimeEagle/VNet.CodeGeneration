using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public abstract class HtmlLineScope<T> : LineScope where T : HtmlLineScope<T>
    {
        protected HtmlLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
                : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}