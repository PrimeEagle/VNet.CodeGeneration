using System.Collections.Generic;

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
        IEnumerable<string> GetNamespaceStyledSyntax(string styledName, NamespaceStyle namespaceStyle, IndentationManager indentLevel);
        IEnumerable<string> GetCommentStyledSyntax(string styledValue, CommentType commentType, IndentationManager indentLevel);
        IEnumerable<string> GetUsingStyledSyntax(string styledValue, IndentationManager indentLevel);
    }
}