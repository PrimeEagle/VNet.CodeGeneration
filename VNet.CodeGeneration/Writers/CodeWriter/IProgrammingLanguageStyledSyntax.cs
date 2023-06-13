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
        IEnumerable<string> GetRegionOpenScope(string styledValue, int currentIndentLevel);
        IEnumerable<string> GetRegionCloseScope(string styledValue, int currentIndentLevel);
        IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetMethodStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetFieldStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetVariableStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetPropertyStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetPropertyGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel);
        IEnumerable<string> GetPropertySetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel);
    }
}