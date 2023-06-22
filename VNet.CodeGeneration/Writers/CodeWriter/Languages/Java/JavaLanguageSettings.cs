//namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
//{
//    public class JavaLanguageSettings : IProgrammingLanguageSettings
//    {
//        public string LanguageName => "Java";
//        public IProgrammingLanguageFeatures Features { get; }
//        public IProgrammingLanguageSyntax Syntax { get; }
//        public IProgrammingLanguageStyle Style { get; }
//        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

//        public JavaLanguageSettings(IProgrammingLanguageStyle style)
//        {
//            Features = new JavaFeatures();
//            Syntax = new JavaSyntax();
//            Style = style;
//            StyledSyntax =new JavaStyledSyntax(Syntax, Style);
//        }
//    }
//}