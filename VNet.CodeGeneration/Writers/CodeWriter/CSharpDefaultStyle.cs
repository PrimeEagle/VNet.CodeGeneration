using System;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CSharpDefaultStyle : ILanguageStyleSettings
    {
        public ILanguageKeywordsSettings Keywords { get; set; }
        public string Indent => UseSpacesForIndentation ? new string(' ', IndentationWidth) : "\t";
        public int IndentLevel { get; set; }
        public BraceStyle BraceStyle { get; set; }
        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? " " + Keywords.OpenScopeCharacter : LineBreakCharacter + GetIndent() + Keywords.OpenScopeCharacter;

        public string CloseScope => BraceStyle == BraceStyle.EndOfLine ? LineBreakCharacter + GetIndent() + Keywords.CloseScopeCharacter : GetIndent() + Keywords.CloseScopeCharacter;


        public int IndentationWidth => 0;
        public bool UseSpacesForIndentation => false;
        public string LineBreakCharacter => Environment.NewLine;
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;

        public string GetIndent()
        {
            return new string(Indent[0], IndentationWidth);
        }

        public string GetOperatorSpacing()
        {
            return SpaceAroundOperators ? " " : string.Empty;
        }




        public CSharpDefaultStyle(ILanguageKeywordsSettings keywords)
        {
            Keywords = keywords;
        }

        public CSharpDefaultStyle()
        {
        }
    }
}