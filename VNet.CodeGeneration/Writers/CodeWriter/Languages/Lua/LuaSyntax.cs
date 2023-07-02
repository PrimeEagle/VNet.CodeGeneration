using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly HashSet<string> ReservedKeywords = new HashSet<string>
        {
            // Add Lua reserved keywords here
            "and", "break", "do", "else", "elseif", "end", "false", "for", "function",
            "goto", "if", "in", "local", "nil", "not", "or", "repeat", "return", "then",
            "true", "until", "while"
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
            if (!Regex.IsMatch(name, @"^[_a-zA-Z][_a-zA-Z0-9]*$"))
            {
                return false;
            }

            // If all checks pass, return true
            return true;
        }
    }
}