using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class MethodScope : JavaBlockScope<MethodScope>
    {
        private string _returnType;
        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<string> _genericConstraints;
        private List<Tuple<string, string>> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;


        public MethodScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
            _parameters = new List<Tuple<string, string>>();
        }

        public MethodScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public MethodScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        public MethodScope WithGenericConstraint(string name)
        {
            _genericConstraints.Add(name);

            return this;
        }

        public MethodScope WithParameter(string type, string name)
        {
            _parameters.Add(new Tuple<string, string>(type, name));

            return this;
        }

        public MethodScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        public MethodScope ThatIsAConstructor()
        {
            Value = this.Parent.Value;
            _returnType = string.Empty;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var genConstraint = string.Join($"{spOp}&{spOp}", _genericConstraints).Trim();
            var gen = $"<{string.Join($",{spComma}", _genericTypes)} {genConstraint}>".Trim();

            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var flattened = _parameters.Select(p => $"{p.Item1} {p.Item2}").ToList();
            var paramStr = string.Join($",{spComma}", flattened).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}{gen}{StyledValue}({paramStr})");
        }
    }
}