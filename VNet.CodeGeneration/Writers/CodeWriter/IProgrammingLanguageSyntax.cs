namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSyntax
    {
        string OpenScopeSymbol { get; }
        string CloseScopeSymbol { get; }


        bool IsValidNaming(string name);
    }
}