namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public class JsonLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "JSON";
        public string DefaultFileExtension => ".json";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public JsonLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new JsonSyntax();
            Style = style;
        }
    }
}