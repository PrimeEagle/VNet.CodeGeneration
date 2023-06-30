namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpLanguageSettings : IProgrammingLanguageSettings
    {
        public string Name => "C#";
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; set; }

        public CSharpLanguageSettings(IProgrammingLanguageStyle style)
        {
            Syntax = new CSharpSyntax();
            Style = style;
        }
    }
}