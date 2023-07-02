namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptDefaultStyle : IProgrammingLanguageStyle
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
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ImportCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Camel;
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
