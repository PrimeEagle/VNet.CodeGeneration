using VNet.CodeGeneration.Writers.StructuredWriter;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator

namespace VNet.Scientific.CodeGen.Writers.StructuredWriter.Languages.Markdown
{
    public class MarkdownSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => string.Empty;
        public string OpenScopeCloseSymbol => string.Empty;
        public string CloseScopeOpenSymbol => string.Empty;
        public string CloseScopeCloseSymbol => string.Empty;
        public string ScopeListSeparatorSymbol => string.Empty;


        public bool IsValidNaming(string name)
        {
            return true;
        }
    }
}