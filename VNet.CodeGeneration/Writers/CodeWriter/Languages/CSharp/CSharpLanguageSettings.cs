namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "C#";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public CSharpLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new CSharpFeatures();
            Syntax = new CSharpSyntax();
            Style = style;
            style.Syntax = Syntax;
        }
    }
}