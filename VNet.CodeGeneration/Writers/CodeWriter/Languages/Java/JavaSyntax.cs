using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
        {
            // Add Java reserved keywords here
            "abstract", "assert", "boolean", "break", "byte", "case", "catch",
            "char", "class", "const", "continue", "default", "do", "double",
            "else", "enum", "exports", "extends", "final", "finally", "float",
            "for", "if", "implements", "import", "instanceof", "int", "interface",
            "long", "module", "native", "new", "null", "package", "private",
            "protected", "public", "requires", "return", "short", "static",
            "strictfp", "super", "switch", "synchronized", "this", "throw",
            "throws", "transient", "true", "try", "var", "void", "volatile",
            "while"
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

            // Check if name starts with a letter or underscore
            if (!Regex.IsMatch(name, @"^[a-zA-Z_$][a-zA-Z0-9_$]*$"))
            {
                return false;
            }

            // If all checks pass, return true
            return true;
        }
    }
}