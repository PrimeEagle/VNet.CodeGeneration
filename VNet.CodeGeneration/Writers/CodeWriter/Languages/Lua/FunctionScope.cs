using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class FunctionScope : LuaBlockScope<FunctionScope>
    {
        private string _returnType;
        private List<string> _modifiers;
        private List<Tuple<string, string>> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;
        protected override string AlternateScopeOpenSymbol => string.Empty;
        protected override string AlternateScopeCloseSymbol => "end";

        public FunctionScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _parameters = new List<Tuple<string, string>>();
        }

        public FunctionScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public FunctionScope WithParameter(string type, string name)
        {
            _parameters.Add(new Tuple<string, string>(type, name));

            return this;
        }

        public FunctionScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var paramStr = string.Join($",{spComma}", _parameters).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}function {StyledValue}({paramStr})");
        }
    }
}