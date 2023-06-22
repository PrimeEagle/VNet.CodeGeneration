using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CPlusPlus
{
    public class CppSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "using namespace";
        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "class";
        public string MethodKeyword => string.Empty;
        public string StaticKeyword => "static";
        public string ReadOnlyKeyword => "const";
        public string ConstantKeyword => "const";
        public string VolatileKeyword => "volatile";
        public string VoidKeyword => "void";
        public string NewKeyword => "new";
        public string PublicKeyword => "public";
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

            // List of C++ keywords
            string[] keywords = new string[] {
                "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand", "bitor", "bool", "break", "case",
                "catch", "char", "char8_t", "char16_t", "char32_t", "class", "compl", "concept", "const",
                "consteval", "constexpr", "constinit", "const_cast", "continue", "co_await", "co_return",
                "co_yield", "decltype", "default", "delete", "do", "double", "dynamic_cast", "else", "enum",
                "explicit", "export", "extern", "false", "float", "for", "friend", "goto", "if", "inline", "int",
                "long", "mutable", "namespace", "new", "noexcept", "not", "not_eq", "nullptr", "operator", "or",
                "or_eq", "private", "protected", "public", "register", "reinterpret_cast", "requires", "return",
                "short", "signed", "sizeof", "static", "static_assert", "static_cast", "struct", "switch", "template",
                "this", "thread_local", "throw", "true", "try", "typedef", "typeid", "typename", "union",
                "unsigned", "using", "virtual", "void", "volatile", "wchar_t", "while", "xor", "xor_eq"
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