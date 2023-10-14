using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // First character must be a letter or an underscore
            if (!char.IsLetter(name[0]) && name[0] != '_')
            {
                return false;
            }

            // The rest of the string must be letters, digits, or underscores
            for (var i = 1; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_')
                {
                    return false;
                }
            }

            // Check for reserved keywords
            var keywords = new List<string>()
            {
                "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class",
                "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event",
                "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if",
                "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new",
                "null", "object", "operator", "out", "override", "params", "private", "protected", "public",
                "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static",
                "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong",
                "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
            };

            if (keywords.Contains(name))
            {
                return false;
            }

            return true;
        }
    }
}