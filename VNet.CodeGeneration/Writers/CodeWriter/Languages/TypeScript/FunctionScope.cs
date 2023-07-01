using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.TypeScript
{
    public class FunctionScope : TypeScriptBlockScope<FunctionScope>
    {
        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<Tuple<string, string>> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;


        public FunctionScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _parameters = new List<Tuple<string, string>>();
        }

        public FunctionScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public FunctionScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        public FunctionScope WithParameter(string type, string name)
        {
            _parameters.Add(new Tuple<string, string>(type, name));

            return this;
        }

        public FunctionScope ThatIsAConstructor()
        {
            Value = "constructor";

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var genType = $"<{string.Join($",{spComma}", _genericTypes)}>".Trim();
            if (genType.Length <= 2) genType = string.Empty;

            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var flattened = _parameters.Select(p => $"{p.Item2}: {p.Item1}").ToList();
            var paramStr = string.Join($",{spComma}", flattened).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}{StyledValue}{genType}({paramStr})");
        }
    }
}