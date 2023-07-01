using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "JavaScript";
        public string DefaultFileExtension => ".js";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public JavaScriptLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new JavaScriptSyntax();
            Style = style;
        }
    }
}