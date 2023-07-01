using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class ClassScope : JavaScriptBlockScope<ClassScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;

        private List<string> _modifiers;
        private string _baseClass;

        public ClassScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _baseClass = string.Empty;
        }

        public FunctionScope AddFunction()
        {
            return AddFunction(string.Empty);
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

        public GetterScope AddSetter(string text)
        {
            var result = new GetterScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ClassScope DerivedFrom(string name)
        {
            _baseClass = name;

            return this;
        }

        public ClassScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var baseClass = !string.IsNullOrEmpty(_baseClass) ? $" extends {_baseClass}" : string.Empty;
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}class {StyledValue}{baseClass}");
        }
    }
}