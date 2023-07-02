﻿using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Common
{
    public class CodeBlockScope : BlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public CodeBlockScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            var splitLines = StyledValue.Split(Lookups.NewLineDelimiters, System.StringSplitOptions.None);
            for(var i = 0; i < splitLines.Length; i++) 
            {
                result.ScopedCodeLines.Add(splitLines[i]);
            }
        }
    }
}