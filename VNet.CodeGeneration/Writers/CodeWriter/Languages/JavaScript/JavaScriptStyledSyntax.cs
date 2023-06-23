using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public JavaScriptStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
        {
            Syntax = syntax;
            Style = style;
        }

        public string GetSingleIndentCode()
        {
            return GetIndentCode(1);
        }

        public string GetIndentCode(int numberOfIndents)
        {
            var indent = Style.UseSpacesForIndentation ? new string(' ', Style.IndentationWidth) : "\t";

            return string.Concat(Enumerable.Repeat(indent, numberOfIndents));
        }

        public IEnumerable<string> GetOpenScope(int currentIndentLevel)
        {
            var result = new List<string>
        {
            Style.ScopeDelimiterStyle == ScopeDelimiterStyle.EndOfLine
                ? " " + Syntax.OpenScopeSymbol
                : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.OpenScopeSymbol
        };

            return result;
        }

        public IEnumerable<string> GetCloseScope(int currentIndentLevel)
        {
            var result = new List<string>
        {
            Style.ScopeDelimiterStyle == ScopeDelimiterStyle.EndOfLine
                ? " " + Syntax.CloseScopeSymbol
                : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.CloseScopeSymbol
        };

            return result;
        }

        public IEnumerable<string> GetCodeGroupingOpenScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
        {
            $"{GetIndentCode(currentIndentLevel)}{Syntax.CodeGroupingOpenSymbol} {styledValue}"
        };

            return result;
        }

        public IEnumerable<string> GetCodeGroupingCloseScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
        {
            $"{GetIndentCode(currentIndentLevel)}{Syntax.CodeGroupingCloseSymbol} {styledValue}"
        };

            return result;
        }

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLine = $"{GetIndentCode(indentLevel.Current)}function {styledValue}({parameters})";

            return new List<string>() { codeLine };
        }

        public IEnumerable<string> GetVariableStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // In JavaScript, the type of the variable is not defined in its declaration
            var codeLine = $"{GetIndentCode(indentLevel.Current)}var {styledValue};";
            
            return new List<string>() { codeLine };
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetModuleStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ModuleStyle namespaceStyle)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetImportStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetEnumerationStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, IEnumerable<EnumerationMember> members)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetFieldStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetSetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetAccessorStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }
    }
}