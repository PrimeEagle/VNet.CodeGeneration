using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageStyleSettings
    {
        IProgrammingLanguageSyntaxSettings Syntax { get; set; }
        int IndentationWidth { get; }
        bool UseSpacesForIndentation { get; }
        BraceStyle BraceStyle { get; }
        string LineBreakCharacter { get; }
        int IndentLevel { get; set; }
        string Indent { get; }
        string OpenScope { get; }
        string CloseScope { get; }
        bool SpaceAroundOperators { get; }
        bool SpaceInsideParentheses { get; }
        bool SpaceOutsideParentheses { get; }
        bool SpaceAfterComma { get; }
        NamespaceStyle NamespaceStyle { get; }
        bool BreakLongLines { get; }
        int MaxLineLength { get; }
        int LineBreakIndentationWidth { get; }
        bool EnableCaseConversion { get; }
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


        string GetIndent();
        string GetOperatorSpacing();
    }
}