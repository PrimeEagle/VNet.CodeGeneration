using System;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonSyntax : IProgrammingLanguageSyntax
    {
        #region Keywords
        public string ImportKeyword => "import";
        public string ModuleKeyword => "module"; // Note: Python doesn't have an exact equivalent to C#'s namespaces. You might use 'module' instead.
        public string ClassKeyword => "class";
        public string FunctionKeyword => "def";
        public string VoidKeyword => string.Empty; // Python does not have a 'void' keyword, a function without a return statement returns None
        public string PublicKeyword => string.Empty; // Python does not have a 'public' keyword. By default, all members are public.
        public string InterfaceKeyword => string.Empty; // Python does not have an 'interface' keyword. It uses duck typing.
        public string StructKeyword => string.Empty; // Python does not have a 'struct' keyword. You might use a simple class instead.
        public string EnumerationKeyword => "enum"; // The enum keyword is not natively supported in Python. This could be accomplished using the enum module.
        public string DelegateKeyword => string.Empty; // Python does not have a 'delegate' keyword. You might use a simple function instead.
        public string EventKeyword => string.Empty; // Python does not have an 'event' keyword. You might use a simple function instead.
        public string AccessorKeyword => string.Empty; // Python does not have an 'accessor' keyword. You might use @property decorator for getters and setters.
        public string GetterKeyword => string.Empty; // In Python, getters are defined using @property decorator and don't have a specific keyword
        public string SetterKeyword => string.Empty; // In Python, setters are defined using @<property>.setter decorator and don't have a specific keyword
        #endregion Keywords

        #region Symbols
        public string StatementEndSymbol => string.Empty; // Python uses newlines to end statements, not a specific symbol
        public string OpenScopeSymbol => ":"; // Python uses indentation to start a new scope after a colon
        public string CloseScopeSymbol => string.Empty; // Python uses dedentation to close scopes, not a specific symbol
        public string CodeGroupingOpenSymbol => string.Empty; // Python does not support regions or similar constructs
        public string CodeGroupingCloseSymbol => string.Empty; // Python does not support regions or similar constructs
        public string GenericScopeOpenSymbol => string.Empty; // Python does not have an equivalent to C#'s generics
        public string GenericScopeCloseSymbol => string.Empty; // Python does not have an equivalent to C#'s generics
        public string EnumerationValueSeparatorSymbol => "=";
        public string EnumerationMemberSeparatorSymbol => ",";
        public string SingleLineCommentSymbol => "#";
        public string MultilineCommentOpenScopeSymbol => "'''"; // Python uses triple quotes for multiline comments
        public string MultilineCommentCloseScopeSymbol => "'''"; // Python uses triple quotes for multiline comments
        public string DocumentationCommentSymbol => "#"; // Python uses "#" for comments. Docstrings (triple quoted strings) are often used for documentation
        public string DocumentationCommentOpenScopeSymbol => "'''\n"; // Python uses triple quotes for docstrings, which are often used for documentation
        public string DocumentationCommentCloseScopeSymbol => "\n'''";
        public string ClassDerivationSymbol => string.Empty;

        bool IProgrammingLanguageSyntax.IsValidNaming(string name)
        {
            throw new NotImplementedException();
        }
        #endregion Symbols
    }
}