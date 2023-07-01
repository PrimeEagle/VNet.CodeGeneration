namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "Python";
        public string DefaultFileExtension => ".py";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public PythonLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new PythonSyntax();
            Style = style;
        }
    }
}