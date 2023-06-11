using System;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpDefaultStyle : IProgrammingLanguageStyleSettings
    {
        public IProgrammingLanguageSyntaxSettings Syntax { get; set; }
        public string Indent => UseSpacesForIndentation ? new string(' ', IndentationWidth) : "\t";
        public int IndentLevel { get; set; }
        public BraceStyle BraceStyle { get; set; }
        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? " " + Syntax.OpenScopeCharacter : LineBreakCharacter + GetIndent() + Syntax.OpenScopeCharacter;

        public string CloseScope => BraceStyle == BraceStyle.EndOfLine ? LineBreakCharacter + GetIndent() + Syntax.CloseScopeCharacter : GetIndent() + Syntax.CloseScopeCharacter;


        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => false;
        public string LineBreakCharacter => Environment.NewLine;
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool BreakLongLines => true;
        public int MaxLineLength => 150;
        public int LineBreakIndentationWidth => 8;
        public NamespaceStyle NamespaceStyle => NamespaceStyle.Scoped;
        public bool EnableCaseConversion => true;
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
        public string GetIndent()
        {
            return new string(Indent[0], IndentationWidth);
        }

        public string GetOperatorSpacing()
        {
            return SpaceAroundOperators ? " " : string.Empty;
        }




        public CSharpDefaultStyle(IProgrammingLanguageSyntaxSettings syntax)
        {
            Syntax = syntax;
        }

        public CSharpDefaultStyle()
        {
        }
    }
}