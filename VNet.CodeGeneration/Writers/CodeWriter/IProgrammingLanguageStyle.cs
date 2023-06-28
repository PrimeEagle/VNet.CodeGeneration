namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageStyle
    {
        #region White Space
        int IndentationWidth { get; }
        bool UseSpacesForIndentation { get; }
        string LineBreakSymbol { get; }
        bool SpaceAroundOperators { get; }
        bool SpaceInsideParentheses { get; }
        bool SpaceOutsideParentheses { get; }
        bool SpaceAfterComma { get; }
        bool SpaceAfterCommentCharacter { get; }
        #endregion White Space


        #region Line Breaks
        bool GenericConstraintsOnSingleLine { get; }
        bool BreakLongLines { get; }
        int MaxLineLength { get; }
        int LineBreakIndentationWidth { get; }
        #endregion Line Breaks


        #region Cases
        bool AutomaticCaseConversion { get; }
        CaseConversionStyle ClassCaseConversionStyle { get; }
        CaseConversionStyle DelegateCaseConversionStyle { get; }
        CaseConversionStyle EnumerationCaseConversionStyle { get; }
        CaseConversionStyle FieldCaseConversionStyle { get; }
        CaseConversionStyle InterfaceCaseConversionStyle { get; }
        CaseConversionStyle FunctionCaseConversionStyle { get; }
        CaseConversionStyle ImportCaseConversionStyle { get; }
        CaseConversionStyle ModuleCaseConversionStyle { get; }
        CaseConversionStyle AccessorCaseConversionStyle { get; }
        CaseConversionStyle GetterCaseConversionStyle { get; }
        CaseConversionStyle SetterCaseConversionStyle { get; }
        CaseConversionStyle CodeGroupingCaseConversionStyle { get; }
        CaseConversionStyle StructCaseConversionStyle { get; }
        CaseConversionStyle VariableCaseConversionStyle { get; }
        #endregion Cases


        #region Scoping
        ScopeDelimiterStyle ScopeDelimiterStyle { get; }
        MultilineCommentStyle MultilineCommentStyle { get; }
        ModuleStyle ModuleStyle { get; }
        #endregion Scoping
    }
}