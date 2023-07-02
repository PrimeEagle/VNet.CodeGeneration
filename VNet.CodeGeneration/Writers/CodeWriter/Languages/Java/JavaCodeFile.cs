using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaCodeFile : JavaBlockScope<JavaCodeFile>, IProgrammingLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => string.Empty;
        protected override string AlternateScopeCloseSymbol => string.Empty;

        protected JavaCodeFile(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        public static JavaCodeFile Create()
        {
            return new JavaCodeFile(null, null, new JavaLanguageSettings(new JavaDefaultStyle()), null, new IndentationManager(), new List<string>());
        }

        public JavaCodeFile WithStyle(IProgrammingLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        public JavaCodeFile AddPackage(string name)
        {
            var result = new PackageScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public JavaCodeFile AddImport(string name)
        {
            var result = new ImportScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public ClassScope AddClass(string name)
        {
            var result = new ClassScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public InterfaceScope AddInterface(string name)
        {
            var result = new InterfaceScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public EnumScope AddEnum(string name)
        {
            var result = new EnumScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}