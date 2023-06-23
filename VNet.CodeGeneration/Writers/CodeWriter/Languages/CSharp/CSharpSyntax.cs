using Microsoft.CSharp;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "using";
        public string ModuleKeyword => "namespace";
        public string ClassKeyword => "clas";
        public string FunctionKeyword => string.Empty;
        public string VoidKeyword => "void";
        public string PublicKeyword => "public";
        public string InterfaceKeyword => "interface";
        public string StructKeyword => "struct";
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => "delegate";
        public string EventKeyword => "event";
        public string AccessorKeyword => string.Empty;
        public string GetterKeyword => "get";
        public string SetterKeyword => "set";
        #endregion Keywords


        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => "#region";
        public string CodeGroupingCloseSymbol => "#endregion";
        public string GenericScopeOpenSymbol => "<";
        public string GenericScopeCloseSymbol => ">";
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "///";
        public string DocumentationCommentOpenScopeSymbol => "/// <summary>";
        public string DocumentationCommentCloseScopeSymbol => "/// </summary>";
        #endregion Symbols


        public bool IsValidNaming(string name)
        {
            return new CSharpCodeProvider().IsValidIdentifier(name);
        }
    }
}