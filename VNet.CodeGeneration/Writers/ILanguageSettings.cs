namespace VNet.CodeGeneration.Writers
{
    public interface ILanguageSettings
    {
        ILanguageFeaturesSettings Features { get; }
        ILanguageKeywordsSettings Keywords { get; }
        ILanguageStyleSettings Style { get; }
    }
}