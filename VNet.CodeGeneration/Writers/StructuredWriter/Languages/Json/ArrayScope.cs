using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public class ArrayScope : JsonBlockScope<ArrayScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;
        protected override string AlternateOpenScopeOpenSymbol => "[";
        protected override string AlternateCloseScopeCloseSymbol => "]";


        public ArrayScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public NameScope AddName(string name)
        {
            var result = new NameScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ObjectScope AddObject(string name)
        {
            var result = new ObjectScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ArrayScope AddArray(string name)
        {
            var result = new ArrayScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
        }
    }
}