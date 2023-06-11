using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

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

        public IEnumerable<string> GetNamespaceCode(string styledName, NamespaceStyle namespaceStyle, List<Scope> scopes, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            switch (namespaceStyle)
            {
                case NamespaceStyle.Scoped:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.UsingKeyword} {styledName}");
                        codeLines.AddRange(GetOpenScope(indentLevel.Current));

                        foreach (var childScope in scopes) codeLines.AddRange(childScope.GenerateCode());

                        codeLines.AddRange(GetCloseScope(indentLevel.Current));
                        indentLevel.Increase();
                        break;
                    }
                case NamespaceStyle.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.UsingKeyword} {styledName};");

                        foreach (var childScope in scopes) codeLines.AddRange(childScope.GenerateCode());

                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }
    }
}