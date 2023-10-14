using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly HashSet<string> keywords = new HashSet<string>
        {
            "auto", "break", "case", "char", "const", "continue", "default",
            "do", "double", "else", "enum", "extern", "float", "for", "goto",
            "if", "inline", "int", "long", "register", "return", "short",
            "signed", "sizeof", "static", "struct", "switch", "typedef",
            "union", "unsigned", "void", "volatile", "while"
        };

        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if name is a C++ keyword
            if (keywords.Contains(name))
            {
                return false;
            }

            // Check the first character
            if (!char.IsLetter(name[0]) && name[0] != '_')
            {
                return false;
            }

            // Check the remaining characters
            for (var i = 1; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
                {
                    return false;
                }
            }

            // If all checks pass, return true
            return true;
        }
    }
}