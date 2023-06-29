namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "Python";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public PythonLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new PythonFeatures();
            Syntax = new PythonSyntax();
            Style = style;
            StyledSyntax = new PythonStyledSyntax(Syntax, Style);
        }
    }
}