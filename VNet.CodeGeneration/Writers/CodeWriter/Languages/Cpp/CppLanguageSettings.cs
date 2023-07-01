namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "C++";
        public string DefaultFileExtension => ".cpp";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public CppLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new CppSyntax();
            Style = style;
        }
    }
}