using System.Text;

namespace VNet.CodeGeneration.Writers.CodeWriter
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

        private string OpenBrace()
        {
            return _languageSettings.BraceStyle == BraceStyle.EndOfLine ? " {" : "\n" + _languageSettings.GetIndent() + "{";
        }

        public void WriteNamespace(string namespaceName)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.NamespaceKeyword} {namespaceName}{OpenBrace()}");
            _languageSettings.IndentLevel++;
        }

        public void WriteClass(string className, AccessModifier modifier = AccessModifier.Public)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.GetAccessModifier(modifier)} {_languageSettings.ClassKeyword} {className}{OpenBrace()}");
            _languageSettings.IndentLevel++;
        }

        public void WriteField(string fieldName, string fieldType, AccessModifier modifier = AccessModifier.Public)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.GetAccessModifier(modifier)} {fieldType} {fieldName}{_languageSettings.StatementEnd}");
        }

        public void WriteProperty(string propertyName, string propertyType, AccessModifier modifier = AccessModifier.Public)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.GetAccessModifier(modifier)} {propertyType} {propertyName} {_languageSettings.PropertySetterGetter}");
        }

        public void WriteMethod(string methodName, string returnType, string[] parameters, string methodBody, AccessModifier modifier = AccessModifier.Public)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.GetAccessModifier(modifier)} {returnType} {methodName}({string.Join(", ", parameters)}){OpenBrace()}");
            _languageSettings.IndentLevel++;
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{methodBody}{_languageSettings.StatementEnd}");
            _languageSettings.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.CloseScope}");
        }

        public void WriteEnum(string enumName, string[] values, AccessModifier modifier = AccessModifier.Public)
        {
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.GetAccessModifier(modifier)} {_languageSettings.EnumKeyword} {enumName}{OpenBrace()}");
            _languageSettings.IndentLevel++;
            foreach (var value in values)
            {
                _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{value},");
            }
            _languageSettings.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.CloseScope}");
        }

        public void CloseScope()
        {
            _languageSettings.IndentLevel--;
            _stringBuilder.AppendLine($"{_languageSettings.GetIndent()}{_languageSettings.CloseScope}");
        }

        public override string ToString()
        {
            return _stringBuilder.ToString();
        }
    }
}