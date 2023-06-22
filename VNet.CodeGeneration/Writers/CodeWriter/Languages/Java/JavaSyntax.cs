using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "import";
        public string NamespaceKeyword => "package";
        public string ClassKeyword => "class";
        public string MethodKeyword => string.Empty;
        public string StaticKeyword => "static";
        public string ReadOnlyKeyword => "final";
        public string ConstantKeyword => "final";
        public string VolatileKeyword => "volatile";
        public string VoidKeyword => "void";
        public string NewKeyword => "new";
        public string PublicKeyword => "public";
        public string InterfaceKeyword => "interface";
        public string StructKeyword => string.Empty;
        public string EnumKeyword => "enum";
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
        public string ConstructorKeyword => string.Empty;
        public string GenericStart => "<";
        public string GenericEnd => ">";
        public string GetKeyword => "get";
        public string SetKeyword => "set";
        public string EnumValueSeparatorCharacter => "=";
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "//";
        public string MultilineCommentOpenScopeCharacter => "/*";
        public string MultilineCommentCloseScopeCharacter => "*/";
        public string DocumentationCommentCharacter => "/**";
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

            // Reserved Java keywords
            string[] keywords = new string[] {
                "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class",
                "const", "continue", "default", "do", "double", "else", "enum", "extends", "final",
                "finally", "float", "for", "goto", "if", "implements", "import", "instanceof", "int",
                "interface", "long", "native", "new", "package", "private", "protected", "public",
                "return", "short", "static", "strictfp", "super", "switch", "synchronized", "this",
                "throw", "throws", "transient", "try", "void", "volatile", "while", "true", "false", "null"
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