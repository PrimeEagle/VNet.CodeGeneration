using System;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter
{
    public class CppLanguageSettings : ILanguageSettings
    {
        public int IndentLevel { get; set; }
        private string Indent => new string(' ', IndentLevel * 2);

        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "class";
        public string EnumKeyword => "enum class";
        public string StatementEnd => ";";
        public string PropertySetterGetter => "";  // C++ does not have built-in property syntax
        public BraceStyle BraceStyle { get; set; }

        public string GetIndent() => Indent;
        public string GetAccessModifier(AccessModifier modifier) => modifier.ToString().ToLower();

        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            throw new NotImplementedException();
        }

        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? " {" : "";
        public string CloseScope => BraceStyle == BraceStyle.EndOfLine ? "\n" + Indent + "}" : "}";
    }
}