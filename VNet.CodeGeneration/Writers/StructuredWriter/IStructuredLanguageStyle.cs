namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public interface IStructuredLanguageStyle
    {
        #region White Space
        int IndentationWidth { get; }
        bool UseSpacesForIndentation { get; }
        string LineBreakSymbol { get; }
        bool SpaceAroundOperators { get; }
        bool SpaceAfterComma { get; }
        bool SpaceAfterCommentCharacter { get; }
        #endregion White Space


        #region Cases
        bool AutomaticCaseConversion { get; }
        CaseConversionStyle ScopeCaseConversionStyle { get; }
        CaseConversionStyle Content { get; }
        CaseConversionStyle AttributeCaseConversionStyle { get; }
        CaseConversionStyle CommentCaseConversionStyle { get; }
        #endregion Cases

        string QuoteSymbol { get; }
    }
}