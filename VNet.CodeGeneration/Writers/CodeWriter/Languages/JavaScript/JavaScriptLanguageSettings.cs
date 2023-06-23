namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "JavaScript";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public JavaScriptLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new JavaScriptFeatures();
            Syntax = new JavaScriptSyntax();
            Style = style;
            StyledSyntax = new JavaScriptStyledSyntax(Syntax, Style);
        }
    }
}