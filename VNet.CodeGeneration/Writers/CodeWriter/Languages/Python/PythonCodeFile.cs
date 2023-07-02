using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonCodeFile : PythonBlockScope<PythonCodeFile>, IProgrammingLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => ":";
        protected override string AlternateScopeCloseSymbol => string.Empty;

        protected PythonCodeFile(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public static PythonCodeFile Create()
        {
            return new PythonCodeFile(null, null, new PythonLanguageSettings(new PythonDefaultStyle()), null, new IndentationManager(), new List<string>());
        }

        public PythonCodeFile WithStyle(IProgrammingLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        public PythonCodeFile AddImport(string name)
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

        public DecoratorScope AddDecorator(string name)
        {
            var result = new DecoratorScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public FunctionScope AddFunction(string name)
        {
            var result = new FunctionScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
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