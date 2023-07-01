using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class GetterScope : LuaBlockScope<GetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.GetterCaseConversionStyle;

        private List<string> _modifiers;


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

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"get");
        }
    }
}