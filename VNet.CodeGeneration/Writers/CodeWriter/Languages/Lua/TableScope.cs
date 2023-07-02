using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class TableScope : LuaBlockScope<TableScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.EnumerationCaseConversionStyle;


        public TableScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public KeyValueScope AddKeyValue(string key, string value)
        {
            var result = new KeyValueScope(key, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ListScope AddList()
        {
            var result = new ListScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"enum {StyledValue}");
        }
    }
}