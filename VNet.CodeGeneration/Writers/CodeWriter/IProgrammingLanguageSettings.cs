namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSettings
    {
        string LanguageName { get; }
        IProgrammingLanguageFeatures Features { get; }
        IProgrammingLanguageSyntax Syntax { get; }
        IProgrammingLanguageStyle Style { get; }
    }
}