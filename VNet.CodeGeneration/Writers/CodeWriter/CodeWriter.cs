using System.Text;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter
{
    public class CodeWriter
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;

        public CodeWriter(ILanguageSettings languageSettings)
        {
            _stringBuilder = new StringBuilder();
            _languageSettings = languageSettings;
        }

        public NamespaceScope BeginNamespace(string namespaceName)
        {
            return new NamespaceScope(namespaceName, _stringBuilder, _languageSettings);
        }

        public override string ToString()
        {
            return _stringBuilder.ToString().Trim();
        }
    }
}