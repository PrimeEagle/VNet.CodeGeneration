using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class PowerShellCodeFile : PowerShellBlockScope<PowerShellCodeFile>, IProgrammingLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => string.Empty;
        protected override string AlternateScopeCloseSymbol => string.Empty;

        protected PowerShellCodeFile(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        public static PowerShellCodeFile Create()
        {
            return new PowerShellCodeFile(null, null, new PowerShellLanguageSettings(new PowerShellDefaultStyle()), null, new IndentationManager(), new List<string>());
        }

        public PowerShellCodeFile WithStyle(IProgrammingLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        public PowerShellCodeFile AddUsing(string name)
        {
            var result = new UsingScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public PowerShellCodeFile AddImport(string name)
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

        public MethodScope AddMethod(string name)
        {
            var result = new MethodScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
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