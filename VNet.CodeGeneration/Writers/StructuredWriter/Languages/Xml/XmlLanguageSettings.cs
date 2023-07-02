namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Xml
{
    public class XmlLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "XML";
        public string DefaultFileExtension => ".xml";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public XmlLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new XmlSyntax();
            Style = style;
        }
    }
}