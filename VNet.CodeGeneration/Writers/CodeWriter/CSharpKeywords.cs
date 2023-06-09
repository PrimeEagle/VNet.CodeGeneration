using System;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CSharpKeywords : ILanguageKeywordsSettings
    {
        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "class";
        public string StaticKeyword => "static";
        public string StatementEnd => ";";
        public string OpenScopeCharacter => "{";
        public string CloseScopeCharacter => "}";
        public string PropertySetterGetter => "{ get; set; }";
        public string GetAccessModifier(AccessModifier modifier)
        {
            return modifier.ToString().ToLower();
        }
        public string PropertyKeyword => string.Empty;
        public string ConstructorKeyword => string.Empty;
        public string UseStatementKeyword => "using";


        public string MethodKeyword => string.Empty;

        public string GenericStart => "<";

        public string GenericEnd => ">";

        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            if (typeArguments.Length == 0)
                return typeName;

            var arguments = string.Join(", ", typeArguments);
            return $"{typeName}<{arguments}>";
        }

        public string GetKeyword => "get";
        public string SetKeyword => "set";

        public string InterfaceKeyword => "interface";

        public string StructKeyword => "struct";

        public string EnumKeyword => "enum";

        public string DelegateKeyword => "delegate";

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
    }
}