using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public class NameScope : JsonBlockScope<NameScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public NameScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
        }

        public ObjectScope AddObject(string name)
        {
            Parameters = null;
            var result = new ObjectScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ArrayScope AddArray(string name)
        {
            Parameters = null;
            var result = new ArrayScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public NameScope WithValue(int value)
        {
            Parameters[0] = value.ToString();
            return this;
        }

        public NameScope WithValue(double value)
        {
            Parameters[0] = value.ToString();
            return this;
        }

        public NameScope WithValue(string value)
        {
            Parameters[0] = $"{qu}{value}{qu}";
            return this;
        }

        public NameScope WithValue(bool value)
        {
            Parameters[0] = (value ? "true" : "false");
            return this;
        }

        public NameScope ThatIsNull()
        {
            Parameters.Add("null");
            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            if (Parameters == null || Parameters.Count == 0) return;

            result.ScopedCodeLines.Add($"{qu}{StyledValue}{qu}{spOp}:{spOp}{qu}{Parameters[0].ToString()}{qu}");
        }
    }
}