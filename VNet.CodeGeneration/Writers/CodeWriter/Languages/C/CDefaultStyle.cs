namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.C
{
    public class CDefaultStyle : IProgrammingLanguageStyle
    {
        #region White Space
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => false; // Use tabs for indentation in C
        public string LineBreakCharacter => "\n"; // Just a newline character is sufficient in Unix-like systems
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        #endregion White Space

        #region Line Breaks
        public bool GenericConstraintsOnSingleLine => true; // C does not support generics, so set to true by default
        public bool BreakLongLines => true;
        public int MaxLineLength => 80; // Traditionally in C, the maximum line length is 80 characters
        public int LineBreakIndentationWidth => 4;
        #endregion Line Breaks

        #region Cases
        public bool AutomaticCaseConversion => false; // Typically, C programmers manually manage their casing style
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Camel; // In C, we typically use Camel case for struct names
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Camel; // In C, constructor functions typically use Camel case
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Camel; // In C, delegate equivalent (function pointers) typically use Camel case
        public CaseConversionStyle EnumerationCaseConversionStyle => CaseConversionStyle.Camel; // Enumerations typically use Camel case in C
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel; // Fields (struct members) typically use Camel case in C
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Camel; // C does not support interfaces, but if they did, they would likely use Camel case
        public CaseConversionStyle FunctionCaseConversionStyle => CaseConversionStyle.Camel; // Functions typically use Camel case in C
        public CaseConversionStyle ModuleCaseConversionStyle => CaseConversionStyle.Title; // In C, modules are typically represented as separate files with Title casing
        public CaseConversionStyle AccessorCaseConversionStyle => CaseConversionStyle.Camel; // In C, accessors (getter/setter functions) would likely use Camel case
        public CaseConversionStyle CodeGroupingCaseConversionStyle => CaseConversionStyle.Title; // Code grouping is typically represented with Title case in comments or preprocessor regions
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Camel; // Structs typically use Camel case in C
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel; // Variables typically use Camel case in C
        #endregion Cases

        #region Scoping
        public ScopeDelimiterStyle ScopeDelimiterStyle => ScopeDelimiterStyle.EndOfLine; // In C, the opening bracket is often placed on the same line
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.SameLine; // The star style is often used for multi-line comments in C
        public ModuleStyle ModuleStyle => ModuleStyle.SingleLine; // C typically uses single files for modules
        #endregion Scoping
    }
}