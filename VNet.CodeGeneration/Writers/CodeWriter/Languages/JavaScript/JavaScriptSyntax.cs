using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
        {
            // Add JavaScript reserved keywords here
            "await", "break", "case", "catch", "class", "const", "continue",
            "debugger", "default", "delete", "do", "else", "enum", "export",
            "extends", "false", "finally", "for", "function", "if", "implements",
            "import", "in", "instanceof", "interface", "let", "new", "null",
            "package", "private", "protected", "public", "return", "super",
            "switch", "this", "throw", "true", "try", "typeof", "var", "void",
            "while", "with", "yield"
        };

        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if name is a reserved keyword
            if (ReservedKeywords.Contains(name))
            {
                return false;
            }

            // Check if name starts with a letter, underscore, or dollar sign
            if (!Regex.IsMatch(name, @"^[a-zA-Z_$][a-zA-Z0-9_$]*$"))
            {
                return false;
            }

            // If all checks pass, return true
            return true;
        }
    }
}