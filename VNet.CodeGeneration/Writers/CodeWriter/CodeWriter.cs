using System.Text;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CodeWriter
    {
        private readonly CodeFile _codeFile;
        private ILanguageSettings _languageSettings;

        public CodeWriter(ILanguageSettings languageSettings)
        {
            _languageSettings= languageSettings;
            _codeFile = new CodeFile(languageSettings);
        }

        public CodeWriter WithUsingStatement(string namespaceName)
        {
            _codeFile.WithUsingStatement(namespaceName);
            return this;
        }

        public NamespaceScope BeginNamespace(string namespaceName)
        {
            return _codeFile.BeginNamespace(namespaceName);
        }

        private StringBuilder AppendWithSpaces(StringBuilder sb, string value, bool spaceBefore = false, bool spaceAfter = false)
        {
            if (_languageSettings.Style.SpaceAroundOperators)
            {
                sb.AppendWithSpaces(value, spaceBefore, spaceAfter);
            }
            else
            {
                sb.Append(value);
            }

            return sb;
        }

        private StringBuilder AppendLineWithSpaces(StringBuilder sb, string value, bool spaceBefore = false, bool spaceAfter = false)
        {
            if (_languageSettings.Style.SpaceAroundOperators)
            {
                sb.AppendWithSpaces(value, spaceBefore, spaceAfter);
                sb.AppendLine();
            }
            else
            {
                sb.AppendLineWithSpaces(value, spaceBefore, spaceAfter);
            }

            return sb;
        }

        public override string ToString()
        {
            return _codeFile.ToString().ApplyWhitespaceSettings(_languageSettings);
        }
    }
}