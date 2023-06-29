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
        #endregion White Space

        #region Line Breaks
        public bool GenericConstraintsOnSingleLine => true;
        public bool BreakLongLines => true;
        public int MaxLineLength => 120;
        public int LineBreakIndentationWidth => 2;
        #endregion Line Breaks

        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Kebab;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases

        #region Scoping
        public ScopeDelimiterStyle ScopeOpenStyle => ScopeDelimiterStyle.SameLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.NewLine;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;
        #endregion Scoping
    }

}