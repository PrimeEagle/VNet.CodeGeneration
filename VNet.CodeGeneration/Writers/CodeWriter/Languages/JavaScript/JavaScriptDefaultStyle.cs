namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 2;
        public bool UseSpacesForIndentation => true;
        public string LineBreakCharacter => "\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => true;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        #endregion White Space


        #region Line Breaks
        public bool BreakLongLines => true;
        public int MaxLineLength => 80;
        public int LineBreakIndentationWidth => 2;
        public bool GenericConstraintsOnSingleLine => true;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Kebab;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases


        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.SameLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.NewLine;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;

        public CaseConversionStyle DelegateCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle EnumerationCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle FieldCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle InterfaceCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle AccessorCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle CodeGroupingCaseConversionStyle => throw new System.NotImplementedException();

        public CaseConversionStyle StructCaseConversionStyle => throw new System.NotImplementedException();
        #endregion Scoping
    }

}
