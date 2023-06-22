using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "import";
        public string NamespaceKeyword => string.Empty;
        public string ClassKeyword => "class";
        public string MethodKeyword => "function";
        public string StaticKeyword => "static";
        public string ReadOnlyKeyword => "const";
        public string ConstantKeyword => "const";
        public string VolatileKeyword => string.Empty;
        public string VoidKeyword => string.Empty;
        public string NewKeyword => "new";
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => string.Empty;
        public string EnumKeyword => string.Empty;
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string StatementEnd => ";";
        public string OpenScopeCharacter => "{";
        public string CloseScopeCharacter => "}";
        public string RegionOpenScopeCharacter => string.Empty;
        public string RegionCloseScopeCharacter => string.Empty;
        public string PropertyKeyword => string.Empty;
        public string PropertyGetterKeyword => "get";
        public string PropertySetterKeyword => "set";
        public string ConstructorKeyword => "constructor";
        public string GenericStart => string.Empty;
        public string GenericEnd => string.Empty;
        public string GetKeyword => "get";
        public string SetKeyword => "set";
        public string EnumValueSeparatorCharacter => string.Empty;
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "//";
        public string MultilineCommentOpenScopeCharacter => "/*";
        public string MultilineCommentCloseScopeCharacter => "*/";
        public string DocumentationCommentCharacter => "//";
        public string DocumentationCommentOpenScopeCharacter => "/**";
        public string DocumentationCommentCloseScopeCharacter => "*/";
        public CaseConversionStyle AccessModifierCaseStyle => CaseConversionStyle.AllLower;

        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if the identifier starts with a letter, $ or _
            if (!char.IsLetter(name[0]) && name[0] != '$' && name[0] != '_')
            {
                return false;
            }

            // After the first character, identifiers can have any combination of characters
            // Make sure the identifier only contains letter, digits, $ or _
            if (!Regex.IsMatch(name, @"^[\p{L}\p{N}_$]+$"))
            {
                return false;
            }

            // Reserved JavaScript keywords
            string[] keywords = new string[] {
                "abstract", "arguments", "await", "boolean", "break", "byte", "case", "catch", "char", "class",
                "const", "continue", "debugger", "default", "delete", "do", "double", "else", "enum", "eval",
                "export", "extends", "false", "final", "finally", "float", "for", "function", "goto", "if",
                "implements", "import", "in", "instanceof", "int", "interface", "let", "long", "native", "new",
                "null", "package", "private", "protected", "public", "return", "short", "static", "super",
                "switch", "synchronized", "this", "throw", "throws", "transient", "true", "try", "typeof",
                "var", "void", "volatile", "while", "with", "yield"
            };

            // A keyword cannot be used as an identifier
            if (Array.Exists(keywords, element => element == name))
            {
                return false;
            }

            return true;
        }
    }
}