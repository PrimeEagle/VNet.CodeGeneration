using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "require";
        public string NamespaceKeyword => string.Empty;
        public string ClassKeyword => string.Empty;
        public string MethodKeyword => string.Empty;
        public string StaticKeyword => string.Empty;
        public string ReadOnlyKeyword => string.Empty;
        public string ConstantKeyword => string.Empty;
        public string VolatileKeyword => string.Empty;
        public string VoidKeyword => string.Empty;
        public string NewKeyword => string.Empty;
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => string.Empty;
        public string EnumKeyword => string.Empty;
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string StatementEnd => "";
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
        public string EnumValueSeparatorCharacter => string.Empty;
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "--";
        public string MultilineCommentOpenScopeCharacter => "--[[";
        public string MultilineCommentCloseScopeCharacter => "]]";
        public string DocumentationCommentCharacter => string.Empty;
        public string DocumentationCommentOpenScopeCharacter => string.Empty;
        public string DocumentationCommentCloseScopeCharacter => string.Empty;
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

            // List of Lua keywords
            string[] keywords = new string[] {
                "and", "break", "do", "else", "elseif", "end", "false", "for", "function", "if",
                "in", "local", "nil", "not", "or", "repeat", "return", "then", "true", "until", "while"
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