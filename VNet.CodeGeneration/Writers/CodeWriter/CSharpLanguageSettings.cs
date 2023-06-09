namespace VNet.Scientific.CodeGen.Writers.CodeWriter
{
    public class CSharpLanguageSettings : ILanguageSettings
    {
        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "class";
        public string EnumKeyword => "enum";
        public string StatementEnd => ";";
        public string PropertySetterGetter => "{ get; set; }";
        public string Indent => "\t";
        public int IndentLevel { get; set; }
        public BraceStyle BraceStyle { get; set; }

        public string GetAccessModifier(AccessModifier modifier)
        {
            return modifier.ToString().ToLower();
        }

        public string GetIndent()
        {
            return new string(Indent[0], IndentLevel);
        }

        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? " {" : "\r\n" + GetIndent() + "{";

        public string CloseScope => BraceStyle == BraceStyle.EndOfLine ? "\r\n" + GetIndent() + "}" : GetIndent() + "}";

        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            if (typeArguments.Length == 0)
                return typeName;

            var arguments = string.Join(", ", typeArguments);
            return $"{typeName}<{arguments}>";
        }
    }
}