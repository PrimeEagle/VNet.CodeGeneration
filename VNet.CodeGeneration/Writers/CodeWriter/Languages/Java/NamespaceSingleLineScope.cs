using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class NamespaceSingleLineScope : JavaLineScope<NamespaceSingleLineScope>
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