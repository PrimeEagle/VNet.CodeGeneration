using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpSyntax : IProgrammingLanguageSyntax
    {
//        //#region Keywords
//        //public string ImportKeyword => "using";
//        //public string ModuleKeyword => "namespace";
//        //public string ClassKeyword => "clas";
//        //public string FunctionKeyword => string.Empty;
//        //public string VoidKeyword => "void";
//        //public string PublicKeyword => "public";
//        //public string InterfaceKeyword => "interface";
//        //public string StructKeyword => "struct";
//        //public string EnumerationKeyword => "enum";
//        //public string DelegateKeyword => "delegate";
//        //public string EventKeyword => "event";
//        //public string AccessorKeyword => string.Empty;
//        //public string GetterKeyword => "get";
//        //public string SetterKeyword => "set";
//        //#endregion Keywords


//        //#region Symbols
//        //public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        //        //public string CodeGroupingOpenSymbol => "#region";
        //        //public string CodeGroupingCloseSymbol => "#endregion";
        //        //public string GenericScopeOpenSymbol => "<";
        //        //public string GenericScopeCloseSymbol => ">";
        //        //public string EnumerationValueSeparatorSymbol => "=";
        //        //public string EnumerationMemberSeparatorSymbol => ",";
        //        //public string SingleLineCommentSymbol => "//";
        //        //public string MultilineCommentOpenScopeSymbol => "/*";
        //        //public string MultilineCommentCloseScopeSymbol => "*/";
        //        //public string DocumentationCommentSymbol => "///";
        //        //public string DocumentationCommentOpenScopeSymbol => "/// <summary>";
        //        //public string DocumentationCommentCloseScopeSymbol => "/// </summary>";
        //        //public string ClassDerivationSymbol => ":";
        //        //#endregion Symbols


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // First character must be a letter or an underscore
            if (!char.IsLetter(name[0]) && name[0] != '_')
            {
                return false;
            }

            // The rest of the string must be letters, digits, or underscores
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
                {
                    return false;
                }
            }

            // Check for reserved keywords
            var keywords = new List<string>()
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class",
                "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event",
                "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if",
                "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new",
                "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
                "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static",
                "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong",
                "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
            };

            if (keywords.Contains(name))
            {
                return false;
            }

            return true;
        }
    }
}