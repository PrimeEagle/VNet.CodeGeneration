using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class PowerShellSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";


        private static readonly List<string> ReservedKeywords = new List<string>
        {
            "Begin", "Process", "End", "Function", "Return", "Filter",
            "Where", "ForEach", "If", "Else", "ElseIf", "Switch", "While",
            "Do", "Until", "For", "Throw", "Try", "Catch", "Finally",
            "Trap", "Data", "Using", "Param", "DynamicParam", "Class",
            "Enum", "DscResource", "RoleCapability", "Continue", "Break",
            "Exit", "Return", "In", "NotIn", "Is", "IsNot", "As",
            "Shl", "Shr", "Band", "Bor", "Bxor", "Ieq", "Ige", "Igt",
            "Ile", "Ilt", "Ine", "Ilike", "Inotlike", "Ireplace", "Icontains",
            "Inotcontains", "Iin", "Inotin", "Isplit", "Ijoin", "Ceq", "Cge",
            "Cgt", "Cle", "Clt", "Cne", "Clike", "Cnotlike", "Creplace",
            "Ccontains", "Cnotcontains", "Cin", "Cnotin", "Csplit", "Cjoin"
        };


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if name is a reserved keyword
            if (ReservedKeywords.Any(keyword => keyword.Equals(name, StringComparison.OrdinalIgnoreCase)))
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