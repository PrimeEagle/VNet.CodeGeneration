﻿using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class NamespaceSingleLineScope : CSharpLineScope<NamespaceSingleLineScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ModuleCaseConversionStyle;


        internal NamespaceSingleLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        protected override void WriteCode(CodeResult result)
        {
            result.UnscopedCodeLines.Add($"namespace {StyledValue};");
        }
    }
}