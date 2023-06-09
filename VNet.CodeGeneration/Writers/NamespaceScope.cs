using System.Text;
using VNet.Scientific.CodeGen.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers
{
    public class NamespaceScope : Scope
    {
        public NamespaceScope(string namespaceName, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            StringBuilder.AppendLine($"{LanguageSettings.GetIndent()}{LanguageSettings.NamespaceKeyword} {namespaceName}{OpenBrace()}");
            LanguageSettings.IndentLevel++;
        }

        private string OpenBrace()
        {
            return LanguageSettings.BraceStyle == BraceStyle.EndOfLine ? " {" : "\r\n" + LanguageSettings.GetIndent() + "{";
        }

        public ClassScope BeginClass(string className, bool isStatic = false, AccessModifier modifier = AccessModifier.Public)
        {
            return new ClassScope(className, isStatic, modifier, StringBuilder, LanguageSettings);
        }
    }
}