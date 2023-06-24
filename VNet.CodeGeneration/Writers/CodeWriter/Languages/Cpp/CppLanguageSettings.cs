namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "C++";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public CppLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new CppFeatures();
            Syntax = new CppSyntax();
            Style = style;
            StyledSyntax = new CppStyledSyntax(Syntax, Style);
        }
    }
}