using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class RegionScope : CSharpBlockScope<RegionScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.CodeGroupingCaseConversionStyle;
        protected override string AlternateScopeOpenSymbol => "#region";
        protected override string AlternateScopeCloseSymbol => "#endregion";

        public RegionScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            result.PostOpenScopeLines.Add(StyledValue);
            result.PostCloseScopeLines.Add(StyledValue);
        }
    }
}