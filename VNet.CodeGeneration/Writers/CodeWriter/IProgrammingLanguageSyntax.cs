namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSyntax
    {
//        //#region Keywords
//        //string ImportKeyword { get; }
//        //string ModuleKeyword { get; }
//        //string ClassKeyword { get; }
//        //string FunctionKeyword { get; }
//        //string VoidKeyword { get; }
//        //string PublicKeyword { get; }
//        //string InterfaceKeyword { get; }
//        //string StructKeyword { get; }
//        //string EnumerationKeyword { get; }
//        //string DelegateKeyword { get; }
//        //string EventKeyword { get; }
//        //string AccessorKeyword { get; }
//        //string GetterKeyword { get; }
//        //string SetterKeyword { get; }
//        //#endregion Keywords


//        //#region Symbols
//        //string StatementEndSymbol { get; }
        string OpenScopeSymbol { get; }
        string CloseScopeSymbol { get; }
//        //string CodeGroupingOpenSymbol { get; }
//        //string CodeGroupingCloseSymbol { get; }
//        //string GenericScopeOpenSymbol { get; }
//        //string GenericScopeCloseSymbol { get; }
//        //string EnumerationValueSeparatorSymbol { get; }
//        //string EnumerationMemberSeparatorSymbol { get; }
//        //string SingleLineCommentSymbol { get; }
//        //string MultilineCommentOpenScopeSymbol { get; }
//        //string MultilineCommentCloseScopeSymbol { get; }
//        //string DocumentationCommentSymbol { get; }
//        //string DocumentationCommentOpenScopeSymbol { get; }
//        //string DocumentationCommentCloseScopeSymbol { get; }
//        //string ClassDerivationSymbol { get; }
//        //#endregion Symbols


        bool IsValidNaming(string name);
    }
}