namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "import";
        public string ModuleKeyword => "module";
        public string ClassKeyword => "class";
        public string FunctionKeyword => "function";
        public string VoidKeyword => "void";
        public string PublicKeyword => "public";
        public string InterfaceKeyword => "interface";
        public string StructKeyword => string.Empty; // TypeScript does not natively support structs.
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => string.Empty; // TypeScript does not natively support delegates.
        public string EventKeyword => string.Empty; // TypeScript does not natively support events.
        public string AccessorKeyword => string.Empty;
        public string GetterKeyword => "get";
        public string SetterKeyword => "set";
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => string.Empty; // TypeScript does not natively support code grouping like C# regions.
        public string CodeGroupingCloseSymbol => string.Empty; // TypeScript does not natively support code grouping like C# regions.
        public string GenericScopeOpenSymbol => "<";
        public string GenericScopeCloseSymbol => ">";
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "*";
        public string DocumentationCommentOpenScopeSymbol => "/**"; // The standard for documentation comments in TypeScript and JavaScript is /** */
        public string DocumentationCommentCloseScopeSymbol => "*/"; // The standard for documentation comments in TypeScript and JavaScript is /** */

        public bool IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }

}
