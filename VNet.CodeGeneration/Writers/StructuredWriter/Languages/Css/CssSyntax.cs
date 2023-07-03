namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class CssSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => string.Empty;
        public string OpenScopeCloseSymbol => "{";
        public string CloseScopeOpenSymbol => string.Empty;
        public string CloseScopeCloseSymbol => "}";
        public string ScopeListSeparatorSymbol => string.Empty;


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (char.IsDigit(name[0]) || (name[0] == '-' && name.Length > 1 && char.IsDigit(name[1])))
                return false;

            for (int i = 0; i < name.Length; i++)
            {
                char c = name[i];
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') ||
                      (c >= '0' && c <= '9') || c == '-' || c == '_' ||
                      (c >= '\u00a1' && c <= '\uffff')))
                    return false;
            }

            return true;
        }

    }
}