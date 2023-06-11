using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageStyledSyntax
    {
        IProgrammingLanguageSyntax Syntax { get; }
        IProgrammingLanguageStyle Style { get; }


        string GetSingleIndentCode();
        string GetIndentCode(int numberOfIndents);
        IEnumerable<string> GetOpenScope(int currentIndentLevel);
        IEnumerable<string> GetCloseScope(int currentIndentLevel);
        IEnumerable<string> GetNamespaceCode(string styledName, NamespaceStyle namespaceStyle, List<Scope> scopes, IndentationManager indentLevel);
    }
}