using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class InterfaceScope : TypeScriptBlockScope<InterfaceScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;

        private List<string> _modifiers;
        private List<string> _genericTypes;
        private string _baseClass;

        public InterfaceScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _baseClass = string.Empty;
        }

        public InterfaceScope AddClass(string text)
        {
            var result = new InterfaceScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public FunctionSignatureScope AddFunctionSignature(string text)
        {
            var result = new FunctionSignatureScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public PropertySignatureScope AddPropertySignature(string text)
        {
            var result = new PropertySignatureScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public InterfaceScope DerivedFrom(string name)
        {
            _baseClass = name;

            return this;
        }

        public InterfaceScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public InterfaceScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var genType = $"<{string.Join($",{spComma}", _genericTypes)}>".Trim();

            var extends = !string.IsNullOrEmpty(_baseClass) ? $" extends {_baseClass}" : string.Empty;

            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}class {StyledValue}{genType}{extends}");
        }
    }
}