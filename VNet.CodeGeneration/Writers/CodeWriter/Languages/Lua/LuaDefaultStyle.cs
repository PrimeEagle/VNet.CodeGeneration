namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaDefaultStyle : IProgrammingLanguageStyle
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
        public int MaxLineLength => 120;
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => false;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.TitleDot;
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.None;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases


        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.SameLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.NewLine;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;
        #endregion Scoping
    }

}