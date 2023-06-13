namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageStyle
    {
        int IndentationWidth { get; }
        bool UseSpacesForIndentation { get; }
        BraceStyle BraceStyle { get; }
        CommentType DefaultCommentType { get; }
        MultilineCommentStyle MultilineCommentStyle { get; }
        string LineBreakCharacter { get; }
        bool SpaceAroundOperators { get; }
        bool SpaceInsideParentheses { get; }
        bool SpaceOutsideParentheses { get; }
        bool SpaceAfterComma { get; }
        bool SpaceAfterCommentCharacter { get; }
        NamespaceStyle NamespaceStyle { get; }
        bool BreakLongLines { get; }
        int MaxLineLength { get; }
        int LineBreakIndentationWidth { get; }
        bool EnableCaseConversion { get; }
        bool GenericConstraintsOnSingleLine { get; }
        CaseConversionStyle ClassCaseConversionStyle { get; }
        CaseConversionStyle ConstructorCaseConversionStyle { get; }
        CaseConversionStyle DelegateCaseConversionStyle { get; }
        CaseConversionStyle EnumCaseConversionStyle { get; }
        CaseConversionStyle FieldCaseConversionStyle { get; }
        CaseConversionStyle InterfaceCaseConversionStyle { get; }
        CaseConversionStyle MethodCaseConversionStyle { get; }
        CaseConversionStyle NamespaceCaseConversionStyle { get; }
        CaseConversionStyle PropertyCaseConversionStyle { get; }
        CaseConversionStyle RegionCaseConversionStyle { get; }
        CaseConversionStyle StructCaseConversionStyle { get; }
        CaseConversionStyle VariableCaseConversionStyle { get; }
    }
}