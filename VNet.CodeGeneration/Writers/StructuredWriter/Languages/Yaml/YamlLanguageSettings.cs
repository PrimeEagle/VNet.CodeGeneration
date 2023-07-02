namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Yaml
{
    public class YamlLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "YAML";
        public string DefaultFileExtension => ".yaml";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public YamlLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new YamlSyntax();
            Style = style;
        }
    }
}