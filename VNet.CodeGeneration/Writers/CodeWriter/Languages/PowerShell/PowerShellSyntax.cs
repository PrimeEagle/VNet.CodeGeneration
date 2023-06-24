namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class PowerShellSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "Import-Module";
        public string ModuleKeyword => string.Empty;
        public string ClassKeyword => "class";
        public string FunctionKeyword => "function";
        public string VoidKeyword => string.Empty; // PowerShell doesn't have a void keyword
        public string PublicKeyword => "public"; // Not really used, but for classes & methods it's implied public 
        public string InterfaceKeyword => string.Empty; // PowerShell does not natively support interfaces
        public string StructKeyword => string.Empty; // PowerShell does not natively support structs
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => string.Empty; // PowerShell does not natively support delegates
        public string EventKeyword => "event";
        public string AccessorKeyword => string.Empty;
        public string GetterKeyword => "get";
        public string SetterKeyword => "set";
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => string.Empty; // PowerShell does not require a statement end symbol
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => "<#";
        public string CodeGroupingCloseSymbol => "#>";
        public string GenericScopeOpenSymbol => string.Empty;
        public string GenericScopeCloseSymbol => string.Empty;
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "#";
        public string MultilineCommentOpenScopeSymbol => "<#";
        public string MultilineCommentCloseScopeSymbol => "#>";
        public string DocumentationCommentSymbol => "<#"; // PowerShell does not natively support doc comments, but we use the multi-line comment symbols here
        public string DocumentationCommentOpenScopeSymbol => "<#";
        public string DocumentationCommentCloseScopeSymbol => "#>";
        public string ClassDerivationSymbol => ":";

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }

}