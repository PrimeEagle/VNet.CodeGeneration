﻿using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp;


namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Common
{
    public class EnumMemberScope : CSharpLineScope<EnumMemberScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public EnumMemberScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            var valStr = string.Empty;
            if(Parameters != null && Parameters.Count > 0 && Parameters[0] != null && int.TryParse(Parameters[0].ToString(), out var intVal))
            {
                valStr = $"{spOp}={spOp}{intVal.ToString()}";
            }

            result.UnscopedCodeLines.Add($"{StyledValue}{valStr},");
        }
    }
}