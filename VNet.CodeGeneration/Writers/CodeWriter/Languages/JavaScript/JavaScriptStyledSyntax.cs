﻿using System;
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

        public IList<string> GetOpenScope(int currentIndentLevel)
        {
            var result = new List<string>
        {
            Style.ScopeDelimiterStyle == ScopeDelimiterStyle.SameLine
                ? " " + Syntax.OpenScopeSymbol
                : Style.LineBreakSymbol + GetIndentCode(currentIndentLevel) + Syntax.OpenScopeSymbol
        };

            return result;
        }

        public IList<string> GetCloseScope(int currentIndentLevel)
        {
            var result = new List<string>
        {
            Style.ScopeDelimiterStyle == ScopeDelimiterStyle.SameLine
                ? " " + Syntax.CloseScopeSymbol
                : Style.LineBreakSymbol + GetIndentCode(currentIndentLevel) + Syntax.CloseScopeSymbol
        };

            return result;
        }

        private string GetCombinedDerived(IList<string> derivedClasses, IEnumerable<string> interfaces)
        {
            if (!derivedClasses.Any() && !interfaces.Any()) return string.Empty;

            var baseClass = derivedClasses.Any() ? new List<string>() { derivedClasses[0] } : new List<string>();
            var combined = baseClass.Concat(interfaces);
            var separator = " ";

            return $"{separator}{Syntax.ClassDerivationSymbol}{separator}{string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)}", combined)}";
        }

        private string GetModifiers(IEnumerable<string> modifiers)
        {
            return !modifiers.Any() ? string.Empty : string.Join(" ", modifiers).Trim();
        }

        private string GetParameters(IEnumerable<string> parameters)
        {
            return string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)} ", parameters).Trim();
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

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> parameters, IList<string> modifiers, IndentationManager indentLevel)
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

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, CommentType commentType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            var values = styledValue.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

            switch (commentType)
            {
                case CommentType.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.SingleLineCommentSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{styledValue}");
                        break;
                    }
                case CommentType.MultiLine:
                    {
                        if (Style.MultilineCommentStyle == MultilineCommentStyle.SameLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                            for (var i = 1; i < values.Length - 1; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.MultilineCommentCloseScopeSymbol}");
                        }

                        if (Style.MultilineCommentStyle == MultilineCommentStyle.NewLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                            for (var i = 1; i < values.Length - 1; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.MultilineCommentCloseScopeSymbol}");
                        }
                    }
                    break;
                case CommentType.Documentation:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentOpenScopeSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                        for (var i = 1; i < values.Length - 1; i++)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[i]}");
                        }

                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.DocumentationCommentCloseScopeSymbol}");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(commentType), commentType, null);
            }

            return codeLines;
        }

        public IEnumerable<string> GetModuleStyledSyntax(string styledValue, ModuleStyle moduleStyle, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetImportStyledSyntax(string styledValue, ImportType importType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.ImportKeyword} {styledValue}{Syntax.StatementEndSymbol}");
            return codeLines;
        }

        public IEnumerable<string> GetEnumerationStyledSyntax(string styledValue, IEnumerable<EnumerationMember> members, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.ClassKeyword} {styledValue}{GetCombinedDerived(derivedFrom, implements)}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetFieldStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetSetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetAccessorStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetCodeGroupingPostScope(string styledValue, int currentIndentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetModulePostScopeStyledSyntax(string styledValue, ModuleStyle moduleStyle, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetCommentPostScopeStyledSyntax(string styledValue, CommentType commentType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetImportPostScopeStyledSyntax(string styledValue, ImportType importType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetEnumerationPostScopeStyledSyntax(string styledValue, IEnumerable<EnumerationMember> members, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetStructPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetInterfacePostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetClassPostScopeStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetDelegatePostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetEventPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetFunctionPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> parameters, IList<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetFieldPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetVariablePostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetAccessorPostScopeStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetGetterPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }

        public IEnumerable<string> GetSetterPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            return new List<string>();
        }
    }
}