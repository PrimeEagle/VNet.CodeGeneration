using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class GetterScope : TypeScriptBlockScope<GetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.GetterCaseConversionStyle;

        private List<string> _modifiers;
        private string _returnType;


        public GetterScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }


        public GetterScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public GetterScope WithReturnType(string type)
        {
            _returnType = type;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"get get{StyledValue}(): {_returnType}");
        }
    }
}