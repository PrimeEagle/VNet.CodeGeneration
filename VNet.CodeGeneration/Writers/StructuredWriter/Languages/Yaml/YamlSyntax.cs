using System.Linq;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Yaml
{
    public class YamlSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => string.Empty;
        public string OpenScopeCloseSymbol => string.Empty;
        public string CloseScopeOpenSymbol => string.Empty;
        public string CloseScopeCloseSymbol => string.Empty;
        public string ScopeListSeparatorSymbol => string.Empty;


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            string[] reservedLiterals = { "true", "false", "null", "~", "y", "Y", "n", "N",
                                  "yes", "Yes", "YES", "no", "No", "NO", "on", "On", "ON",
                                  "off", "Off", "OFF" };

            if (reservedLiterals.Contains(name))
                return false;

            if (name[0] == '@' || name[0] == '`')
                return false;

            char[] specialCharacters = { ':', '{', '}', '[', ']', ',', '&', '*', '#',
                                 '?', '|', '-', '<', '>', '=', '!', '%', '@', '\'' };

            if (name.IndexOfAny(specialCharacters) >= 0)
                return false;

            return true;
        }

    }
}