using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public CSharpStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
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

            var singleCode = new string(indent[0], Style.IndentationWidth);

            return string.Concat(Enumerable.Repeat(singleCode, numberOfIndents));
        }

        public IEnumerable<string> GetOpenScope(int currentIndentLevel)
        {
            var result = new List<string>
            {
                Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + Syntax.OpenScopeCharacter
                    : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.OpenScopeCharacter
            };

            return result;
        }

        public IEnumerable<string> GetCloseScope(int currentIndentLevel)
        {
            var result = new List<string>
            {
                Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + Syntax.CloseScopeCharacter
                    : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.CloseScopeCharacter
            };

            return result;
        }

        public IEnumerable<string> GetNamespaceStyledSyntax(string styledValue, NamespaceStyle namespaceStyle, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            switch (namespaceStyle)
            {
                case NamespaceStyle.Scoped:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.NamespaceKeyword} {styledValue}");
                        break;
                    }
                case NamespaceStyle.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.NamespaceKeyword} {styledValue}{Syntax.StatementEnd}");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, CommentType commentType, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            var values = styledValue.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

            switch (commentType)
            {
                case CommentType.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.SingleLineCommentCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{styledValue}");
                        break;
                    }
                case CommentType.MultiLine:
                    {
                        if (Style.MultilineCommentStyle == MultilineCommentStyle.SameLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.MultilineCommentCloseScopeCharacter}");
                        }

                        if (Style.MultilineCommentStyle == MultilineCommentStyle.NewLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeCharacter}{values[0]}");
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}");
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentCloseScopeCharacter}");
                        }
                    }
                    break;
                case CommentType.Documentation:
                    codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentOpenScopeCharacter}{values[0]}");
                    foreach (var t in values)
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{t}");
                    }

                    // TODO: doesn't support documentation for parameters
                    codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentCloseScopeCharacter}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        public IEnumerable<string> GetUsingStyledSyntax(string styledValue, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.UsingKeyword} {styledValue}{Syntax.StatementEnd}");

            return codeLines;
        }
    }
}