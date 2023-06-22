using System;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonSyntax : IProgrammingLanguageSyntax
    {
        public string UsingKeyword => "import";
        public string NamespaceKeyword => string.Empty;
        public string ClassKeyword => "class";
        public string MethodKeyword => "def";
        public string StaticKeyword => "@staticmethod";
        public string ReadOnlyKeyword => string.Empty;
        public string ConstantKeyword => string.Empty;
        public string VolatileKeyword => string.Empty;
        public string VoidKeyword => string.Empty;
        public string NewKeyword => string.Empty;
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => string.Empty;
        public string EnumKeyword => "from enum import Enum";
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string StatementEnd => "";
        public string OpenScopeCharacter => "";
        public string CloseScopeCharacter => "";
        public string RegionOpenScopeCharacter => string.Empty;
        public string RegionCloseScopeCharacter => string.Empty;
        public string PropertyKeyword => string.Empty;
        public string PropertyGetterKeyword => string.Empty;
        public string PropertySetterKeyword => string.Empty;
        public string ConstructorKeyword => "__init__";
        public string GenericStart => string.Empty;
        public string GenericEnd => string.Empty;
        public string GetKeyword => "@property";
        public string SetKeyword => "@<property>.setter";
        public string EnumValueSeparatorCharacter => string.Empty;
        public string EnumMemberSeparatorCharacter => ",";
        public string SingleLineCommentCharacter => "#";
        public string MultilineCommentOpenScopeCharacter => "'''";
        public string MultilineCommentCloseScopeCharacter => "'''";
        public string DocumentationCommentCharacter => "#";
        public string DocumentationCommentOpenScopeCharacter => "'''";
        public string DocumentationCommentCloseScopeCharacter => "'''";
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

            // List of Python keywords
            string[] keywords = new string[] {
                "and", "as", "assert", "async", "await", "break", "class", "continue", "def", "del", "elif",
                "else", "except", "False", "finally", "for", "from", "global", "if", "import", "in", "is",
                "lambda", "None", "nonlocal", "not", "or", "pass", "raise", "return", "True", "try",
                "while", "with", "yield"
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