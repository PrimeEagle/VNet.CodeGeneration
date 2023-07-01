namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "Java";
        public string DefaultFileExtension => ".java";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public JavaLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new JavaSyntax();
            Style = style;
        }
    }
}