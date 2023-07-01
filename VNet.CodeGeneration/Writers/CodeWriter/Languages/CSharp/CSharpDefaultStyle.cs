using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
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
        public int MaxLineLength => 185;
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ImportCaseConversionStyle => CaseConversionStyle.TitleDot;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.TitleDot;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle GetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle SetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        #endregion Cases


        #region Scoping
        public ScopeStyle ScopeOpenStyle => ScopeStyle.NewLine;
        public ScopeStyle ScopeCloseStyle => ScopeStyle.NewLine;
        public ScopeStyle MultilineCommentStyle => ScopeStyle.NewLine;
        #endregion Scoping
    }
}