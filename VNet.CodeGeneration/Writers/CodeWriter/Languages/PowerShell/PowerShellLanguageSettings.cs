namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class PowerShellLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "PowerShell";
        public string DefaultFileExtension => ".ps1";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public PowerShellLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new PowerShellSyntax();
            Style = style;
        }
    }
}