using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class MetatableScope : LuaBlockScope<MetatableScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;
        
        private List<string> _modifiers;

        public MetatableScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public MetatableScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {          
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var param = string.Empty;
            if(Parameters != null &&  Parameters.Count > 0)
            {
                param = Parameters[0].ToString();
            }
            result.PreOpenScopeLines.Add($"{modifiers}setmetatable({StyledValue},{param})");
        }
    }
}