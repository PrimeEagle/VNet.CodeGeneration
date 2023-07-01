using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "TypeScript";
        public string DefaultFileExtension => ".ts";
        public bool EnforceDefaultFileExtension => true;
        public string DefaultFileExtensionPrefix => ".g";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public TypeScriptLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new TypeScriptSyntax();
            Style = style;
        }
    }
}