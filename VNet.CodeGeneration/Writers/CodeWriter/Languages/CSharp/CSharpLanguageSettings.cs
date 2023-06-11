namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "C#";
        public IProgrammingLanguageFeatureSettings Features { get; }
        public IProgrammingLanguageSyntaxSettings Syntax { get; }
        public IProgrammingLanguageStyleSettings Style { get; }

        public CSharpLanguageSettings(IProgrammingLanguageStyleSettings style)
        {
            Features = new CSharpFeatures();
            Syntax = new CSharpSyntax();
            Style = style;
            style.Syntax = Syntax;
        }
    }
}