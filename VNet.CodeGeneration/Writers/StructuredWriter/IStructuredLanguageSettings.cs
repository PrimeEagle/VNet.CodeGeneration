namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public interface IStructuredLanguageSettings
    {
        IStructuredLanguageFeatureSettings Features { get; }
        IStructuredLanguageKeywordSettings Keywords { get; }
        IStructuredLanguageStyleSettings Style { get; }
    }
}