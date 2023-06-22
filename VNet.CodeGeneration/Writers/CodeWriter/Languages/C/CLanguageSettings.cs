namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "C";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public CLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new CFeatures();
            Syntax = new CSSyntax();
            Style = style;
            StyledSyntax =new CStyledSyntax(Syntax, Style);
        }
    }
}