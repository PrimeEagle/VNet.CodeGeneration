using System;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter
{
    public class FSharpLanguageSettings : ILanguageSettings
    {
        public int IndentLevel { get; set; }
        private string Indent => new string(' ', IndentLevel * 4);

        public string NamespaceKeyword => "namespace";
        public string ClassKeyword => "type";
        public string EnumKeyword => "type";
        public string StatementEnd => "";
        public string PropertySetterGetter => "with get, set";
        public BraceStyle BraceStyle { get; set; }

        public string GetIndent() => Indent;
        public string GetAccessModifier(AccessModifier modifier) => "";  // F# does not have access modifiers

        public string GetGenericType(string typeName, params string[] typeArguments)
        {
            throw new NotImplementedException();
        }

        public string OpenScope => BraceStyle == BraceStyle.EndOfLine ? Environment.NewLine + Indent + "    " + "with" : " =";
        public string CloseScope => "";
    }
}