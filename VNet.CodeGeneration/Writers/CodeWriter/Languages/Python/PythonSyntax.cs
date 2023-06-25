using System;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "import";
        public string ModuleKeyword => "module";
        public string ClassKeyword => "class";
        public string FunctionKeyword => "def";
        public string VoidKeyword => string.Empty;
        public string PublicKeyword => string.Empty;
        public string InterfaceKeyword => string.Empty;
        public string StructKeyword => string.Empty;
        public string EnumerationKeyword => "Enum";
        public string DelegateKeyword => string.Empty;
        public string EventKeyword => string.Empty;
        public string AccessorKeyword => string.Empty;
        public string GetterKeyword => string.Empty;
        public string SetterKeyword => string.Empty;
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => string.Empty;
        public string OpenScopeSymbol => ":";
        public string CloseScopeSymbol => string.Empty;
        public string CodeGroupingOpenSymbol => string.Empty;
        public string CodeGroupingCloseSymbol => string.Empty;
        public string GenericScopeOpenSymbol => string.Empty;
        public string GenericScopeCloseSymbol => string.Empty;
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => string.Empty;
        public string SingleLineCommentSymbol => "#";
        public string MultilineCommentOpenScopeSymbol => "\"\"\"";
        public string MultilineCommentCloseScopeSymbol => "\"\"\"";
        public string DocumentationCommentSymbol => string.Empty;
        public string DocumentationCommentOpenScopeSymbol => string.Empty;
        public string DocumentationCommentCloseScopeSymbol => string.Empty;
        public string ClassDerivationSymbol => string.Empty;

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new NotImplementedException();
        }
        #endregion Symbols
    }
}