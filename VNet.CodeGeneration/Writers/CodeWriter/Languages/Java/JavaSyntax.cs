namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "import";
        public string ModuleKeyword => "package";
        public string ClassKeyword => "class";
        public string FunctionKeyword => string.Empty; // Java doesn't use a keyword for declaring methods
        public string VoidKeyword => "void";
        public string PublicKeyword => "public";
        public string InterfaceKeyword => "interface";
        public string StructKeyword => string.Empty; // Java doesn't support structures
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => string.Empty; // Java doesn't support delegates
        public string EventKeyword => string.Empty; // Java doesn't have an equivalent concept for C# events
        public string AccessorKeyword => string.Empty; // Java doesn't use a keyword for property accessors
        public string GetterKeyword => "get"; // Not a keyword, but a convention for getter methods
        public string SetterKeyword => "set"; // Not a keyword, but a convention for setter methods
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => string.Empty; // Java doesn't have an equivalent concept for C# regions
        public string CodeGroupingCloseSymbol => string.Empty; // Java doesn't have an equivalent concept for C# regions
        public string GenericScopeOpenSymbol => "<";
        public string GenericScopeCloseSymbol => ">";
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "*"; // This is the convention for JSDoc comments within the multi-line comment
        public string DocumentationCommentOpenScopeSymbol => "/**"; // JSDoc comments start with this symbol
        public string DocumentationCommentCloseScopeSymbol => "*/"; // JSDoc comments end with this symbol
        public string ClassDerivationSymbol => "extends";

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }

}
