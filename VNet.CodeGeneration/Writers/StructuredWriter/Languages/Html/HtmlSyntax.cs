namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class HtmlSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => "<";
        public string OpenScopeCloseSymbol => ">";
        public string CloseScopeOpenSymbol => "</";
        public string CloseScopeCloseSymbol => ">";
        public string ScopeListSeparatorSymbol => string.Empty;


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (!((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z')))
                return false;

            for (int i = 1; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') ||
                      (name[i] >= '0' && name[i] <= '9') || name[i] == '-' || name[i] == '_' || name[i] == '.' || name[i] == ':'))
                    return false;
            }
            return true;
        }

    }
}