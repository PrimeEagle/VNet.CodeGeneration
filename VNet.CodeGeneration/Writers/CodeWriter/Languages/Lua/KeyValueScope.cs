using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class KeyValueScope : LuaLineScope<KeyValueScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public KeyValueScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            var key = Value ?? string.Empty;
            var val = string.Empty;
            if(Parameters != null && Parameters.Count > 0) 
            {
                val = Parameters[0].ToString();
            }

            var valStr = string.Empty;
            if(int.TryParse(val, out var i)) 
            {
                valStr = $"{key}{spOp}={spOp}{val}";
            }
            else
            {
                valStr = $"{key}{spOp}={spOp}\"{val}\"";
            }

            result.ScopedCodeLines.Add($"{valStr},");
        }
    }
}