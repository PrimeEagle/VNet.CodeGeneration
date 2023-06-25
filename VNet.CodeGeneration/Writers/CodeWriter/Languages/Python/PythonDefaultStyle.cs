namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => true;
        public string LineBreakCharacter => "\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        #endregion White Space


        #region Line Breaks
        public bool GenericConstraintsOnSingleLine => true;
        public bool BreakLongLines => true;
        public int MaxLineLength => 79;
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Upper;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Snake;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Snake;
        #endregion Cases


        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.Indented;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.Indented;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;
        #endregion Scoping
    }

}