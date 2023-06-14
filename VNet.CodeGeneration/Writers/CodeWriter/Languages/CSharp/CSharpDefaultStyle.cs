using System;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpDefaultStyle : IProgrammingLanguageStyle
    {
        public BraceStyle BraceStyle { get; set; }
        public CommentType DefaultCommentType => CommentType.SingleLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.SameLine;
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => false;
        public string LineBreakCharacter => "\r\n";
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
        public bool BreakLongLines => true;
        public int MaxLineLength => 150;
        public int LineBreakIndentationWidth => 8;
        public NamespaceStyle NamespaceStyle => NamespaceStyle.Scoped;
        public bool AutomaticCaseConversion => true;
        public bool GenericConstraintsOnSingleLine => false;
        public CaseConversionStyle ClassCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle ConstructorCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle DelegateCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle EnumCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle FieldCaseConversionStyle => CaseConversionStyle.Camel;
        public CaseConversionStyle InterfaceCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle MethodCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle NamespaceCaseConversionStyle => CaseConversionStyle.TitleDot;
        public CaseConversionStyle PropertyCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle RegionCaseConversionStyle => CaseConversionStyle.Title;
        public CaseConversionStyle StructCaseConversionStyle => CaseConversionStyle.Pascal;
        public CaseConversionStyle VariableCaseConversionStyle => CaseConversionStyle.Camel;
    }
}