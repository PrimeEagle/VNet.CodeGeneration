namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class XmlSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => "<";
        public string OpenScopeCloseSymbol => ">";
        public string CloseScopeOpenSymbol => "</";
        public string CloseScopeCloseSymbol => ">";


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            if (name.Length >= 3 && name.Substring(0, 3).ToLower() == "xml")
                return false;

            if (!((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z') || name[0] == '_'))
                return false;

            for (int i = 1; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') ||
                      (name[i] >= '0' && name[i] <= '9') || name[i] == '-' || name[i] == '_' || name[i] == '.'))
                    return false;
            }

            return true;
        }
    }
}