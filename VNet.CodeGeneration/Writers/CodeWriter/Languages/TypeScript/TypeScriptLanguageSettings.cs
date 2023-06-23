using VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class TypeScriptLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "TypeScript";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public TypeScriptLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new TypeScriptFeatures();
            Syntax = new TypeScriptSyntax();
            Style = style;
            StyledSyntax = new TypeScriptStyledSyntax(Syntax, Style);
        }
    }
}