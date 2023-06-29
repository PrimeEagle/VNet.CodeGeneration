using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Common
{
    public class EnumMemberScope : LineScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public EnumMemberScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCodeLines(CodeResult result)
        {
            var opSpace = LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
            var valStr = string.Empty;
            if(Parameters != null && Parameters.Count > 0 && int.TryParse(Parameters[0].ToString(), out var intVal))
            {
                valStr = $"{opSpace}={opSpace}{intVal.ToString()}";
            }

            result.UnscopedCodeLines.Add($"{StyledValue}{valStr}");
        }
    }
}