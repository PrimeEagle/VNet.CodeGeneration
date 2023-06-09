namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CSharpLanguageSettings : ILanguageSettings
    {
        public ILanguageFeaturesSettings Features { get; }
        public ILanguageKeywordsSettings Keywords { get; }
        public ILanguageStyleSettings Style { get; }

        public CSharpLanguageSettings(ILanguageStyleSettings style)
        {
            Features = new CSharpFeatures();
            Keywords = new CSharpKeywords();
            Style = style;
            style.Keywords = Keywords;
        }
    }
}