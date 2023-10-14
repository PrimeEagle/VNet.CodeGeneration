using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Markdown
{
    public abstract class MarkdownLineScope<T> : LineScope where T : MarkdownLineScope<T>
    {
        protected MarkdownLineScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    :        base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }
    }
}