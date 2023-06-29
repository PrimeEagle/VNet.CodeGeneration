namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageSettings
    {
        string Name { get; }
        //IProgrammingLanguageFeatures Features { get; }
        IProgrammingLanguageSyntax Syntax { get; }
        IProgrammingLanguageStyle Style { get; set; }
        //IProgrammingLanguageStyledSyntax StyledSyntax { get; }
    }
}