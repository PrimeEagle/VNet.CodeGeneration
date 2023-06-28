using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class NamespaceSingleLineScope : LineScope
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ModuleCaseConversionStyle;


        internal NamespaceSingleLineScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { 
        }

        protected override void WriteCodeLines()
        {
            CodeLines.Add($"{GetIndent(IndentLevel.Current)}namespace {StyledValue};");
        }
    }
}