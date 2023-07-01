using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 2;
        public bool UseSpacesForIndentation => true;
        public string LineBreakSymbol => "\r\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        public bool SpaceBeforeSameLineScope => true;
        #endregion White Space


        #region Line Breaks
        public bool GenericConstraintsOnSingleLine => false;
        public bool BreakLongLines => true;
        public int MaxLineLength => 80;
        public int LineBreakIndentationWidth => 2;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ImportCaseConversionStyle => CaseConversionStyle.Lower;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Lower;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle GetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle SetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Lower;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases


        #region Scoping
        public ScopeStyle ScopeOpenStyle => ScopeStyle.SameLine;
        public ScopeStyle ScopeCloseStyle => ScopeStyle.NewLine;
        public ScopeStyle MultilineCommentStyle => ScopeStyle.NewLine;
        #endregion Scoping
    }

}
