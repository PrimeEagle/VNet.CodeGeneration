using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.C
{
    public class CSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => string.Empty;
        public string NamespaceKeyword => string.Empty;
        public string ClassKeyword => string.Empty;
        public string MethodKeyword => string.Empty;
        public string StaticKeyword => "static";
        public string ReadOnlyKeyword => "const";
        public string ConstantKeyword => "#define";
        public string VolatileKeyword => "volatile";
        public string VoidKeyword => "void";
        public string NewKeyword => string.Empty;
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => "struct";
        public string EnumKeyword => "enum";
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string StatementEnd => ";";
        public string OpenScopeCharacter => "{";
        public string CloseScopeCharacter => "}";
        public string RegionOpenScopeCharacter => string.Empty;
        public string RegionCloseScopeCharacter => string.Empty;
        public string PropertyKeyword => string.Empty;
        public string PropertyGetterKeyword => string.Empty;
        public string PropertySetterKeyword => string.Empty;
        public string ConstructorKeyword => string.Empty;
        public string GenericStart => string.Empty;
        public string GenericEnd => string.Empty;
        public string GetKeyword => string.Empty;
        public string SetKeyword => string.Empty;
        public string EnumValueSeparatorCharacter => "=";
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "//";
        public string MultilineCommentOpenScopeCharacter => "/*";
        public string MultilineCommentCloseScopeCharacter => "*/";
        public string DocumentationCommentCharacter => "/*";
        public string DocumentationCommentOpenScopeCharacter => "/*";
        public string DocumentationCommentCloseScopeCharacter => "*/";
        public CaseConversionStyle AccessModifierCaseStyle => CaseConversionStyle.AllLower;

        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if the identifier starts with a letter or _
            if (!char.IsLetter(name[0]) && name[0] != '_')
            {
                return false;
            }

            // After the first character, identifiers can have any combination of characters
            // Make sure the identifier only contains letter, digits, or _
            if (!Regex.IsMatch(name, @"^[\p{L}\p{N}_]+$"))
            {
                return false;
            }

            // List of C keywords
            string[] keywords = new string[] {
                "auto", "break", "case", "char", "const", "continue", "default", "do", "double", "else",
                "enum", "extern", "float", "for", "goto", "if", "int", "long", "register", "return", "short",
                "signed", "sizeof", "static", "struct", "switch", "typedef", "union", "unsigned", "void", "volatile", "while"
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