using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Css
{
    public class DeclarationScope : CssLineScope<DeclarationScope>
    {

        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;


        public DeclarationScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        protected override void WriteCode(CodeResult result)
        {
            if (Parameters != null && Parameters.Count > 0)
            {
                result.InsideOpenScope.Add($"{StyledValue}:{SpOp}{Parameters[0].ToString()};");
            }
        }
    }
}