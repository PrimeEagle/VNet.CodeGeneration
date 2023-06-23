namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "import";
        public string ModuleKeyword => string.Empty;  // JavaScript doesn't have a direct equivalent for modules/namespaces
        public string ClassKeyword => "class";
        public string FunctionKeyword => "function";
        public string VoidKeyword => "undefined";
        public string PublicKeyword => string.Empty;  // JavaScript doesn't have a direct equivalent for public
        public string InterfaceKeyword => string.Empty; // JavaScript doesn't have a direct equivalent for interfaces
        public string StructKeyword => string.Empty; // JavaScript doesn't have a direct equivalent for structs
        public string EnumerationKeyword => string.Empty; // JavaScript doesn't have a direct equivalent for enums
        public string DelegateKeyword => string.Empty; // JavaScript doesn't have a direct equivalent for delegates
        public string EventKeyword => string.Empty; // JavaScript doesn't have a direct equivalent for events
        public string AccessorKeyword => string.Empty; // JavaScript doesn't have a keyword for defining accessors
        public string GetterKeyword => "get";
        public string SetterKeyword => "set";
        #endregion Keywords


        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => string.Empty; // JavaScript doesn't have a direct equivalent for regions
        public string CodeGroupingCloseSymbol => string.Empty; // JavaScript doesn't have a direct equivalent for regions
        public string GenericScopeOpenSymbol => string.Empty; // JavaScript doesn't have a direct equivalent
        public string GenericScopeCloseSymbol => string.Empty; // JavaScript doesn't have a direct equivalent
        public string EnumerationValueSeparatorSymbol => ":"; // JavaScript doesn't have enums, but this is typically how you would separate keys from values in an object
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "*";
        public string DocumentationCommentOpenScopeSymbol => "/**"; // JSDoc uses this to start a documentation comment
        public string DocumentationCommentCloseScopeSymbol => "*/"; // JSDoc uses this to end a documentation comment
        public string ClassDerivationSymbol => "extends";

        public bool IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }
}