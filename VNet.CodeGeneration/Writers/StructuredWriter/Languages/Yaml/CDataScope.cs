using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Yaml
{
    public class CDataScope : YamlBlockScope<CDataScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateOpenScopeOpenSymbol => "<![CDATA[";
        protected override string AlternateCloseScopeCloseSymbol => "]]>";


        public CDataScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public CDataMemberScope AddCDataMember()
        {
            var result = new CDataMemberScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}