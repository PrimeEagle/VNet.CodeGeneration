namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSettings
    {
        string LanguageName { get; }
        IProgrammingLanguageFeatureSettings Features { get; }
        IProgrammingLanguageSyntaxSettings Syntax { get; }
        IProgrammingLanguageStyleSettings Style { get; }
    }
}