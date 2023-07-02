namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 2;
        public bool UseSpacesForIndentation => true;
        public string LineBreakSymbol => "\n";
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
        public int MaxLineLength => 120;
        public int LineBreakIndentationWidth => 2;
        #endregion Line Breaks

        #region Cases
        public bool AutomaticCaseConversion => false;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle ImportCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle GetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle SetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.None;
        #endregion Cases

        #region Scoping
        public ScopeStyle ScopeOpenStyle => ScopeStyle.NewLine;
        public ScopeStyle ScopeCloseStyle => ScopeStyle.NewLine;
        public ScopeStyle MultilineCommentStyle => ScopeStyle.NewLine;
        #endregion Scoping
    }

}