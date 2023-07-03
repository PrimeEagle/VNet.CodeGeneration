﻿using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class ClassSelectorScope : CssBlockScope<ClassSelectorScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public ClassSelectorScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public ClassSelectorScope AddDeclaration(string property, string value)
        {
            var result = new DeclarationScope(property, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.InsideOpenScope.Add($".{StyledValue}");
        }
    }
}