namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Html
{
    public class HtmlLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "HTML";
        public string DefaultFileExtension => ".html";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public HtmlLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new HtmlSyntax();
            Style = style;
        }
    }
}