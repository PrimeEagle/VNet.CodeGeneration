namespace VNet.Scientific.CodeGen.Writers.StructuredWriter
{
    public interface IStructuredLanguageSettings
    {
        IStructuredLanguageFeatureSettings Features { get; }
        IStructuredLanguageKeywordSettings Keywords { get; }
        IStructuredLanguageStyleSettings Style { get; }
    }
}