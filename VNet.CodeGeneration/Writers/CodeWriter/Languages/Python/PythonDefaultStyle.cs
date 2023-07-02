namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
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
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks

        #region Cases
        public bool AutomaticCaseConversion => false;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle ImportCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle GetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle SetterCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        #endregion Cases

        #region Scoping
        public ScopeStyle ScopeOpenStyle => ScopeStyle.SameLine;
        public ScopeStyle ScopeCloseStyle => ScopeStyle.SameLine;
        public ScopeStyle MultilineCommentStyle => ScopeStyle.NewLine;
        #endregion Scoping
    }

}