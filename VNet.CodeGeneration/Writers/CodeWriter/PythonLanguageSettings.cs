using System;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter
{
    public class PythonLanguageSettings : ILanguageSettings
    {
        public int IndentLevel { get; set; }
        private string Indent => new string(' ', IndentLevel * 4);

        public string NamespaceKeyword => "class";  // Python doesn't have namespaces, but a class can serve a similar purpose
        public string ClassKeyword => "class";
        public string EnumKeyword => "class";
        public string StatementEnd => "";
        public string PropertySetterGetter => "";  // Python does not have built-in property syntax
        public BraceStyle BraceStyle { get; set; }

        public string GetIndent() => Indent;
        public string GetAccessModifier(AccessModifier modifier) => "";  // Python does not have access modifiers

        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            throw new NotImplementedException();
        }

        public string OpenScope => ":";
        public string CloseScope => "";
    }
}
