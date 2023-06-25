using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public LuaStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
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
            return new List<string>
        {
            GetIndentCode(currentIndentLevel) + Syntax.OpenScopeSymbol
        };
        }

        public IEnumerable<string> GetCloseScope(int currentIndentLevel)
        {
            return new List<string>
        {
            GetIndentCode(currentIndentLevel) + Syntax.CloseScopeSymbol
        };
        }

        public IEnumerable<string> GetCodeGroupingOpenScope(string styledValue, int currentIndentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetCodeGroupingCloseScope(string styledValue, int currentIndentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetModuleStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ModuleStyle namespaceStyle)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType)
        {
            return new List<string>
        {
            GetIndentCode(indentLevel.Current) + Syntax.SingleLineCommentSymbol + " " + styledValue
        };
        }

        public IEnumerable<string> GetImportStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>
        {
            GetIndentCode(indentLevel.Current) + "require(\"" + styledValue + "\")"
        };
        }

        public IEnumerable<string> GetEnumerationStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, IEnumerable<EnumerationMember> members)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>
        {
            GetIndentCode(indentLevel.Current) + styledValue + " = {}",
            GetIndentCode(indentLevel.Current) + "setmetatable(" + styledValue + ", {__index = " + (derivedFrom.FirstOrDefault() ?? "{}") + "})"
        };
        }

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, string returnType, IEnumerable<FunctionParameter> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var paramString = string.Join(", ", parameters.Select(param => param.Name));
            var codeLines = new List<string>
        {
            GetIndentCode(indentLevel.Current) + "function " + styledValue + "(" + paramString + ")",
            GetIndentCode(indentLevel.Increase()) + "-- function body",
            GetIndentCode(indentLevel.Decrease()) + "end"
        };
            return codeLines;
        }

        public IEnumerable<string> GetPropertyStyledSyntax(string styledValue, string type, bool hasGet, bool hasSet, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // Lua doesn't have an explicit concept of properties. Here we're creating a table
            // with getter and setter functions. This is a very basic and not fully equivalent way to emulate properties in Lua.
            var codeLines = new List<string>();
            if (hasGet)
            {
                codeLines.Add(GetIndentCode(indentLevel.Current) + "function get_" + styledValue + "() return " + styledValue + " end");
            }
            if (hasSet)
            {
                codeLines.Add(GetIndentCode(indentLevel.Current) + "function set_" + styledValue + "(value) " + styledValue + " = value end");
            }
            return codeLines;
        }

        public IEnumerable<string> GetFieldStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>
                {
                    GetIndentCode(indentLevel.Current) + styledValue + " = nil"
                };
        }
    }
}
}