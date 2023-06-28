namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => true;
        public string LineBreakSymbol => "\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => true;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        #endregion White Space


        #region Line Breaks
        public bool GenericConstraintsOnSingleLine => false; // C++ does not have a concept of generic constraints, but templates are usually broken into multiple lines for readability.
        public bool BreakLongLines => true;
        public int MaxLineLength => 80; // A common standard in C++ coding conventions.
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks


        #region Cases
        public bool AutomaticCaseConversion => true;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal; // Constructors in C++ typically use the same case as the class.
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Camel; // C++ does not have a concept of delegates, so this could be a placeholder.
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal; // C++ does not have a concept of interfaces, so this could be a placeholder.
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.TitleDot; // The module could be a file, so it's commonly snake case.
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Camel; // C++ does not have a concept of accessors, so this could be a placeholder.
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
        #endregion Cases


        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.SameLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.NewLine;
        public ModuleStyle ModuleStyle => ModuleStyle.Scoped;
        #endregion Scoping
    }

}