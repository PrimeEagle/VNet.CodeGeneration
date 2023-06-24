namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "#include";
        public string ModuleKeyword => "using namespace";
        public string ClassKeyword => "class";
        public string FunctionKeyword => string.Empty; // C++ does not have a specific keyword for functions
        public string VoidKeyword => "void";
        public string PublicKeyword => "public";
        public string InterfaceKeyword => string.Empty; // C++ does not have an explicit interface keyword
        public string StructKeyword => "struct";
        public string EnumerationKeyword => "enum";
        public string DelegateKeyword => string.Empty; // C++ uses function pointers or std::function instead of delegates
        public string EventKeyword => string.Empty; // C++ does not have a built-in event keyword
        public string AccessorKeyword => string.Empty; // C++ does not have a specific accessor keyword
        public string GetterKeyword => string.Empty; // C++ does not have a specific getter keyword
        public string SetterKeyword => string.Empty; // C++ does not have a specific setter keyword
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => ";";
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        public string CodeGroupingOpenSymbol => string.Empty; // C++ does not have a specific region keyword
        public string CodeGroupingCloseSymbol => string.Empty; // C++ does not have a specific endregion keyword
        public string GenericScopeOpenSymbol => "<";
        public string GenericScopeCloseSymbol => ">";
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "//";
        public string MultilineCommentOpenScopeSymbol => "/*";
        public string MultilineCommentCloseScopeSymbol => "*/";
        public string DocumentationCommentSymbol => "*"; // Usually "//" is used for documentation, though doxygen-style "/** ... */" comments are also common
        public string DocumentationCommentOpenScopeSymbol => "/**"; // doxygen-style opening
        public string DocumentationCommentCloseScopeSymbol => "*/"; // doxygen-style closing
        public string ClassDerivationSymbol => ":";

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
        #endregion Symbols
    }
}