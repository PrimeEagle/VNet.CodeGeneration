namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class CssLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "CSS";
        public string DefaultFileExtension => ".css";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public CssLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new CssSyntax();
            Style = style;
        }
    }
}