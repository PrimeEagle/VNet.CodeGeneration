namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "require";
        public string ModuleKeyword => string.Empty;  // Lua doesn't have a direct equivalent to namespaces
        public string ClassKeyword => string.Empty;   // Lua doesn't have a built-in class keyword
        public string FunctionKeyword => "function";
        public string VoidKeyword => string.Empty;    // Lua does not distinguish void from any other type
        public string PublicKeyword => string.Empty;  // Lua doesn't have access modifiers like public, private, etc.
        public string InterfaceKeyword => string.Empty;  // Lua doesn't have a built-in interface keyword
        public string StructKeyword => string.Empty;  // Lua doesn't have a struct keyword
        public string EnumerationKeyword => string.Empty;  // Lua doesn't have a built-in enum keyword
        public string DelegateKeyword => string.Empty;  // Lua doesn't have a built-in delegate keyword
        public string EventKeyword => string.Empty;   // Lua doesn't have a built-in event keyword
        public string AccessorKeyword => string.Empty;   // Lua doesn't have a built-in accessor keyword
        public string GetterKeyword => string.Empty;  // Lua doesn't have a built-in get keyword
        public string SetterKeyword => string.Empty;  // Lua doesn't have a built-in set keyword
        #endregion Keywords


        #region Symbols
        public string StatementEndSymbol => string.Empty; // In Lua, end of line or a new block denotes end of statement
        public string OpenScopeSymbol => "do";
        public string CloseScopeSymbol => "end";
        public string CodeGroupingOpenSymbol => string.Empty;
        public string CodeGroupingCloseSymbol => string.Empty;
        public string GenericScopeOpenSymbol => string.Empty;  // Lua doesn't have a built-in generic scope symbol
        public string GenericScopeCloseSymbol => string.Empty;  // Lua doesn't have a built-in generic scope symbol
        public string EnumerationValueSeparatorSymbol => string.Empty;  // Lua doesn't have a built-in enumeration value separator
        public string EnumerationMemberSeparatorSymbol => string.Empty;
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