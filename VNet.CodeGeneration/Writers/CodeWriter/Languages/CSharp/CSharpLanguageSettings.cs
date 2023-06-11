namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "C#";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public CSharpLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new CSharpFeatures();
            Syntax = new CSharpSyntax();
            Style = style;
            StyledSyntax =new CSharpStyledSyntax(Syntax, Style);
        }
    }
}