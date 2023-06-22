namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaLanguageSettings : IProgrammingLanguageSettings
    {
        public string LanguageName => "Lua";
        public IProgrammingLanguageFeatures Features { get; }
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }
        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

        public LuaLanguageSettings(IProgrammingLanguageStyle style)
        {
            Features = new LuaFeatures();
            Syntax = new LuaSyntax();
            Style = style;
            StyledSyntax =new LuaStyledSyntax(Syntax, Style);
        }
    }
}