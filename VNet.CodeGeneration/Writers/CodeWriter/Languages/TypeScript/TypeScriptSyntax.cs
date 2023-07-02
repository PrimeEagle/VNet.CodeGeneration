using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
        {
            // Add TypeScript reserved keywords here
            "abstract", "as", "any", "boolean", "break", "case", "catch", "class",
            "const", "continue", "debugger", "declare", "default", "delete", "do",
            "else", "enum", "export", "extends", "false", "finally", "for",
            "from", "function", "get", "if", "implements", "import", "in",
            "infer", "instanceof", "interface", "is", "keyof", "let", "module",
            "namespace", "never", "new", "null", "number", "object", "package",
            "private", "protected", "public", "readonly", "require", "return",
            "set", "static", "string", "super", "switch", "symbol", "this", "throw",
            "true", "try", "type", "typeof", "undefined", "unique", "unknown",
            "var", "void", "while", "with", "yield"
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
            if (!Regex.IsMatch(name, @"^[a-zA-Z_][a-zA-Z0-9_]*$"))
            {
                return false;
            }

            // If all checks pass, return true
            return true;
        }
    }
}