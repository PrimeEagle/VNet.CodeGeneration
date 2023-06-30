using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class InterfaceScope : CSharpBlockScope<InterfaceScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.InterfaceCaseConversionStyle;


        public InterfaceScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}