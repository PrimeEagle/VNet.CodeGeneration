namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => true;
        public string LineBreakCharacter => "\r\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
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
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.TitleDot;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases


        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.NewLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.NewLine;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;
        #endregion Scoping
    }
}