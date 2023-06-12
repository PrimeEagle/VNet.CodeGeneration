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
        IEnumerable<string> GetNamespaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, NamespaceStyle namespaceStyle);
        IEnumerable<string> GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType);
        IEnumerable<string> GetUsingStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetEnumStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, IEnumerable<EnumMember> members);
        IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel);
    }
}