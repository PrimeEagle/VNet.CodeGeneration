namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.C
{
    public class CSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "#include"; // C does not have an import keyword
        public string ModuleKeyword => string.Empty; // C does not have a module keyword
        public string ClassKeyword => string.Empty; // C does not have a class keyword
        public string FunctionKeyword => string.Empty; // C does not have a function keyword
        public string VoidKeyword => "void";
        public string PublicKeyword => string.Empty; // C does not have a public keyword
        public string InterfaceKeyword => string.Empty; // C does not have an interface keyword
        public string StructKeyword => "struct";
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => string.Empty; // C does not have a delegate keyword
        public string EventKeyword => string.Empty; // C does not have an event keyword
        public string AccessorKeyword => string.Empty; // C does not have an accessor keyword
        public string GetterKeyword => string.Empty; // C does not have a getter keyword
        public string SetterKeyword => string.Empty; // C does not have a setter keyword
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => string.Empty; // C does not have code grouping symbols
        public string CodeGroupingCloseSymbol => string.Empty; // C does not have code grouping symbols
        public string GenericScopeOpenSymbol => string.Empty; // C does not have a generic scope
        public string GenericScopeCloseSymbol => string.Empty; // C does not have a generic scope
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "/*"; // C does not have a specific documentation comment symbol, so we use multiline comment symbols
        public string DocumentationCommentOpenScopeSymbol => "/*";
        public string DocumentationCommentCloseScopeSymbol => "*/";

        string IProgrammingLanguageSyntax.ClassDerivationSymbol => throw new System.NotImplementedException();

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }
}