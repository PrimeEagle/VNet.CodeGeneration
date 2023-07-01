using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class SetterSignatureScope : CppExtendedLineScope<SetterSignatureScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.SetterCaseConversionStyle;


        private List<string> _modifiers;
        private List<Tuple<string, string>> _parameters;


        public SetterSignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _parameters = new List<Tuple<string, string>>();
        }

        public SetterSignatureScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public SetterSignatureScope WithParameter(string type, string name)
        {
            _parameters.Add(new Tuple<string, string>(type, name));

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var flattened = _parameters.Select(p => $"{p.Item1} {p.Item2}").ToList();
            var paramStr = string.Join($",{spComma}", flattened).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}set({paramStr});");
        }
    }
}