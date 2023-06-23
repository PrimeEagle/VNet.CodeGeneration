//namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
//{
//    public class PowerShellLanguageSettings : IProgrammingLanguageSettings
//    {
//        public string LanguageName => "PowerShell";
//        public IProgrammingLanguageFeatures Features { get; }
//        public IProgrammingLanguageSyntax Syntax { get; }
//        public IProgrammingLanguageStyle Style { get; }
//        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

//        public JavaLanguageSettings(IProgrammingLanguageStyle style)
//        {
//            Features = new PowerShellFeatures();
//            Syntax = new PowerShellSyntax();
//            Style = style;
//            StyledSyntax =new PowerShellStyledSyntax(Syntax, Style);
//        }
//    }
//}