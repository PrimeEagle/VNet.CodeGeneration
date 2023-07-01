namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSettings
    {
        string Name { get; }
        string DefaultFileExtension { get; }
        bool EnforceDefaultFileExtension { get; }
        string DefaultFileExtensionPrefix { get; }
        IProgrammingLanguageSyntax Syntax { get; }
        IProgrammingLanguageStyle Style { get; set; }
    }
}