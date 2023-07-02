using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class ClassScope : PythonBlockScope<ClassScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;
        
        private List<string> _modifiers;
        private string _baseClass;

        public ClassScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _baseClass = string.Empty;
        }

        public ClassScope AddClass(string text)
        {
            var result = new ClassScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public FunctionScope AddFunction(string text)
        {
            var result = new FunctionScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public EnumScope AddEnum(string text)
        {
            var result = new EnumScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public GetterScope AddGetter(string text)
        {
            var result = new GetterScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public SetterScope AddSetter(string text)
        {
            var result = new SetterScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public DecoratorScope AddDecorator(string name)
        {
            var result = new DecoratorScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ClassScope DerivedFrom(string name)
        {
            _baseClass = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var derive = !string.IsNullOrEmpty(_baseClass) ? $"({_baseClass})" : string.Empty;

            result.PreOpenScopeLines.Add($"class {StyledValue}{derive}");
        }
    }
}