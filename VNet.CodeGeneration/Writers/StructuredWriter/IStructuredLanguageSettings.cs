namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public interface IStructuredLanguageSettings
    {
        string Name { get; }
        string DefaultFileExtension { get; }
        bool EnforceDefaultFileExtension { get; }
        string DefaultFileExtensionPrefix { get; }
        IStructuredLanguageSyntax Syntax { get; }
        IStructuredLanguageStyle Style { get; set; }
    }
}