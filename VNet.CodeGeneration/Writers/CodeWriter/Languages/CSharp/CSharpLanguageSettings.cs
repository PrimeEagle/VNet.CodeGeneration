namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "C#";
        public string DefaultFileExtension => ".cs";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public CSharpLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new CSharpSyntax();
            Style = style;
        }
    }
}