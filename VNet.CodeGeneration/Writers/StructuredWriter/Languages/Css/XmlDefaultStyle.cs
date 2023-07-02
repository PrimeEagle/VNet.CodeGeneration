namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class XmlDefaultStyle : IStructuredLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => true;
        public string LineBreakSymbol => "\r\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        #endregion White Space


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ScopeCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle Content => CaseConversionStyle.Pascal;
        public CaseConversionStyle AttributeCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle CommentCaseConversionStyle => CaseConversionStyle.None;
        #endregion Cases

        public string QuoteSymbol => "\"";
    }
}