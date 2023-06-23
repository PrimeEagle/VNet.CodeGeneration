﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public TypeScriptStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
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

        private string GetModifiers(IEnumerable<string> modifiers)
        {
            return !modifiers.Any() ? string.Empty : string.Join(" ", modifiers).Trim();
        }

        private string GetParameters(IEnumerable<string> parameters)
        {
            return string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)} ", parameters).Trim();
        }

        public string GetCodeGroupingOpenSymbol()
        {
            return Syntax.CodeGroupingOpenSymbol;
        }

        public string GetCodeGroupingCloseSymbol()
        {
            return Syntax.CodeGroupingCloseSymbol;
        }

        public IEnumerable<string> GetModuleStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ModuleStyle namespaceStyle)
        {
            return new List<string>() { $"{Syntax.ModuleKeyword} {styledValue} {GetOpenScope(0).First()}" };
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.InterfaceKeyword} {styledValue}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.InterfaceKeyword} {styledValue}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.DelegateKeyword} {styledValue}({GetParameters(parameters)}){Syntax.StatementEndSymbol}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.EventKeyword} {styledValue}{Syntax.StatementEndSymbol}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetAccessorStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {type} {Syntax.AccessorKeyword} {CodeWriter.ConvertStyleCase(styledValue, Style.AccessorCaseConversionStyle)}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.GetterKeyword}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetSetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.SetterKeyword}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetCodeGroupingOpenScope(string styledValue, int currentIndentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetCodeGroupingCloseScope(string styledValue, int currentIndentLevel)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType)
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


        public IEnumerable<string> GetImportStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.ImportKeyword} {styledValue} from '{styledValue}';");
            return codeLines;
        }

        public IEnumerable<string> GetEnumerationStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, IEnumerable<EnumerationMember> members)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.EnumerationKeyword} {styledValue} {GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();
            return codeLines;
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.ClassKeyword} {styledValue} {GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();
            return codeLines;
        }

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} function {styledValue}({GetParameters(parameters)}){GetColonAndReturnType(returnType)} {GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();
            return codeLines;
        }

        public IEnumerable<string> GetFieldStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {styledValue}{GetColonAndType(type)};");
            return codeLines;
        }

        public IEnumerable<string> GetVariableStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} let {styledValue}{GetColonAndType(type)};");
            return codeLines;
        }

        private string GetColonAndType(string type)
        {
            return type != null ? $": {type}" : string.Empty;
        }

        private string GetColonAndReturnType(string returnType)
        {
            return returnType != null ? $": {returnType}" : string.Empty;
        }

        IEnumerable<string> IProgrammingLanguageStyledSyntax.GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType)
        {
            throw new System.NotImplementedException();
        }
    }
}