using System;
using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Yaml
{
    public class KeyValuePairScope : YamlBlockScope<KeyValuePairScope>
    {
        private string _content;
        private List<Tuple<string, string>> _attributes;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ScopeCaseConversionStyle;


        public KeyValuePairScope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _attributes = new List<Tuple<string, string>>();
        }

        public KeyValuePairScope AddKeyValuePair(string key, string value)
        {
            var result = new KeyValuePairScope(key, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            var val = Scopes.Count == 0 && Parameters != null && Parameters.Count > 0 ? Parameters[0].ToString() : string.Empty; 

            result.InsideOpenScope.Add($"{StyledValue}:{val}");
        }
    }
}