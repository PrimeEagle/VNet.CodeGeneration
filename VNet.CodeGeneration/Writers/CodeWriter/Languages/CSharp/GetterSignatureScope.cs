using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class GetterSignatureScope : CSharpBlockScope<GetterSignatureScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.GetterCaseConversionStyle;


        private List<string> _modifiers;


        public GetterSignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public GetterSignatureScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            result.PreOpenScopeLines.Add($"get;");
        }
    }
}