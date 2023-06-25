namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "require";
        public string ModuleKeyword => string.Empty;
        public string ClassKeyword => "setmetatable";
        public string FunctionKeyword => "function";
        public string VoidKeyword => string.Empty;
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => string.Empty;
        public string EnumerationKeyword => string.Empty;
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string AccessorKeyword => string.Empty;
        public string GetterKeyword => string.Empty;
        public string SetterKeyword => string.Empty;
        #endregion Keywords


        #region Symbols
        public string StatementEndSymbol => string.Empty; // In Lua, end of line or a new block denotes end of statement
        public string OpenScopeSymbol => "do";
        public string CloseScopeSymbol => "end";
        public string CodeGroupingOpenSymbol => string.Empty;
        public string CodeGroupingCloseSymbol => string.Empty;
        public string GenericScopeOpenSymbol => string.Empty;  // Lua doesn't have a built-in generic scope symbol
        public string GenericScopeCloseSymbol => string.Empty;  // Lua doesn't have a built-in generic scope symbol
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "--";
        public string MultilineCommentOpenScopeSymbol => "--[[";
        public string MultilineCommentCloseScopeSymbol => "--]]";
        public string DocumentationCommentSymbol => string.Empty;
        public string DocumentationCommentOpenScopeSymbol => string.Empty;
        public string DocumentationCommentCloseScopeSymbol => string.Empty;
        public string ClassDerivationSymbol => string.Empty;

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }
}