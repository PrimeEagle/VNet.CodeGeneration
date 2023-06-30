using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class GetterScope : CSharpBlockScope<GetterScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.GetterCaseConversionStyle;


        public GetterScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

       

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}