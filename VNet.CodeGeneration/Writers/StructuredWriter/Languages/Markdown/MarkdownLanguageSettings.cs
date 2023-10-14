using VNet.CodeGeneration.Writers.StructuredWriter;

namespace VNet.Scientific.CodeGen.Writers.StructuredWriter.Languages.Markdown
{
    public class MarkdownLanguageSettings : IStructuredLanguageSettings
    {
        public string Name => "Markdown";
        public string DefaultFileExtension => ".md";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => string.Empty;
        public IStructuredLanguageSyntax Syntax { get; }
        public IStructuredLanguageStyle Style { get; set; }

        public MarkdownLanguageSettings(IStructuredLanguageStyle style)
        {
            Syntax = new MarkdownSyntax();
            Style = style;
        }
    }
}