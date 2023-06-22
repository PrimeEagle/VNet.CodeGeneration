//namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
//{
//    public class CPlusPlusLanguageSettings : IProgrammingLanguageSettings
//    {
//        public string LanguageName => "C++";
//        public IProgrammingLanguageFeatures Features { get; }
//        public IProgrammingLanguageSyntax Syntax { get; }
//        public IProgrammingLanguageStyle Style { get; }
//        public IProgrammingLanguageStyledSyntax StyledSyntax { get; }

//        public CPlusPlusLanguageSettings(IProgrammingLanguageStyle style)
//        {
//            Features = new CPlusPlusFeatures();
//            Syntax = new CPlusPlusSyntax();
//            Style = style;
//            StyledSyntax =new CPlusPlusStyledSyntax(Syntax, Style);
//        }
//    }
//}