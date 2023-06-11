using System;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpDefaultStyle : IProgrammingLanguageStyle
    {
        public IProgrammingLanguageSyntax Syntax { get; set; }
        public BraceStyle BraceStyle { get; set; }
        public CommentType DefaultCommentType => CommentType.SingleLine;
        public MultilineCommentStyle MultilineCommentStyle => MultilineCommentStyle.SameLine;
        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? " " + Syntax.OpenScopeCharacter : LineBreakCharacter + GetIndent() + Syntax.OpenScopeCharacter;
        public string CloseScope => BraceStyle == BraceStyle.EndOfLine ? LineBreakCharacter + GetIndent() + Syntax.CloseScopeCharacter : GetIndent() + Syntax.CloseScopeCharacter;
        public int IndentationWidth => 4;
        public bool UseSpacesForIndentation => false;
        public string LineBreakCharacter => Environment.NewLine;
        public bool SpaceAroundOperators => true;
        public bool SpaceInsideParentheses => false;
        public bool SpaceOutsideParentheses => false;
        public bool SpaceAfterComma => true;
        public bool SpaceAfterCommentCharacter => true;
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
            var indent = UseSpacesForIndentation ? new string(' ', IndentationWidth) : "\t";
            
            return new string(indent[0], IndentationWidth);
        }

        public string GetAccessModifier(AccessModifier modifier)
        {
            return modifier.ToString().ToLower();
        }
        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            if (typeArguments.Length == 0)
                return typeName;

            var arguments = string.Join(", ", typeArguments);
            return $"{typeName}<{arguments}>";
        }

        public string GetAttributeSyntax(string attributeName, params string[] args)
        {
            var formattedArgs = string.Join(", ", args.Select(arg => $"\"{arg}\""));
            
            return $"{attributeName}({formattedArgs})";
        }

        public string GetCommentSyntax(string comment, CommentType commentType)
        {
            var isMultiline = comment.Contains("\r") || comment.Contains("\n");

            if (commentType == CommentType.Documentation)
            {
                if (isMultiline)
                {
                    var lines = comment.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    var formattedLines = lines.Select(line => $"/// {line}");
                    return $"/**\n{string.Join("\n", formattedLines)}\n**/";
                }
                else
                {
                    return $"/// {comment}";
                }
            }
            else
            {
                if (isMultiline)
                {
                    var lines = comment.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                    var formattedLines = lines.Select(line => $"* {line}");
                    return $"/**\n{string.Join("\n", formattedLines)}\n**/";
                }
                else
                {
                    return $"// {comment}";
                }
            }
        }

        public CSharpDefaultStyle(IProgrammingLanguageSyntax syntax)
        {
            Syntax = syntax;
        }

        public CSharpDefaultStyle()
        {
        }
    }
}