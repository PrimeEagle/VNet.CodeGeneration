using System;
using System.Collections.Generic;


namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class GetterSignatureScope : CppExtendedLineScope<GetterSignatureScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.GetterCaseConversionStyle;


        private string _returnType;
        private string _namespace;
        private List<string> _modifiers;


        public GetterSignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public GetterSignatureScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public GetterSignatureScope WithNamespace(string name)
        {
            _namespace = name;

            return this;
        }

        public GetterSignatureScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var ns = !string.IsNullOrEmpty(_namespace) ? $"{_namespace}::" : string.Empty;

            result.PreOpenScopeLines.Add($"{modifiers}get;");
        }
    }
}