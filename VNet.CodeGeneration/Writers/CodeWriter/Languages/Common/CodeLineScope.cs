﻿using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Common
{
    public class CodeLineScope : LineScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CodeLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCodeLines(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"{StyledValue}");
        }
    }
}