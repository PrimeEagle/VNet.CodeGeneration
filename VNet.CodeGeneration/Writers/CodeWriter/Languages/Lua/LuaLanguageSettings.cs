namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "Lua";
        public string DefaultFileExtension => ".lua";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public LuaLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new LuaSyntax();
            Style = style;
        }
    }
}