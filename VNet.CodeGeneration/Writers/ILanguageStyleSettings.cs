namespace VNet.CodeGeneration.Writers
{
    public interface ILanguageStyleSettings
    {
        ILanguageKeywordsSettings Keywords { get; set; }
        int IndentationWidth { get; }
        bool UseSpacesForIndentation { get; }
        BraceStyle BraceStyle { get; }
        string LineBreakCharacter { get; }
        int IndentLevel { get; set; }
        string Indent { get; }
        string OpenScope { get; }
        string CloseScope { get; }
        bool SpaceAroundOperators { get; }
        bool SpaceInsideParentheses { get; }
        bool SpaceOutsideParentheses { get; }
        bool SpaceAfterComma { get; }


        string GetIndent();
        string GetOperatorSpacing();
    }
}