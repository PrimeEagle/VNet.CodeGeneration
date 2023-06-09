using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class CodeFile
    {
        private readonly StringBuilder _stringBuilder;
        private readonly ILanguageSettings _languageSettings;
        private readonly List<string> _usingStatements;

        public CodeFile(ILanguageSettings languageSettings)
        {
            _stringBuilder = new StringBuilder();
            _languageSettings = languageSettings;
            _usingStatements = new List<string>();
        }

        public CodeFile WithUsingStatement(string namespaceName)
        {
            if (!string.IsNullOrWhiteSpace(namespaceName) && _languageSettings.Features.SupportsUsingStatements)
            {
                _usingStatements.Add(namespaceName);
            }
            return this;
        }

        public override string ToString()
        {
            var codeBuilder = new StringBuilder();

            if (_languageSettings.Features.SupportsUsingStatements)
            {
                foreach (var usingStatement in _usingStatements)
                {
                    codeBuilder.AppendLine($"{_languageSettings.Keywords.UseStatementKeyword} {usingStatement};");
                }

                if (_usingStatements.Any())
                {
                    codeBuilder.AppendLine();
                }
            }

            codeBuilder.Append(_stringBuilder);

            return codeBuilder.ToString();
        }

        public NamespaceScope BeginNamespace(string namespaceName)
        {
            return new NamespaceScope(namespaceName, _stringBuilder, _languageSettings);
        }
    }
}