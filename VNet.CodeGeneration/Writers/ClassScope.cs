using System.Text;

namespace VNet.Scientific.CodeGen.Writers
{
    public class ClassScope : Scope
    {
        public ClassScope(string className, bool isStatic, AccessModifier modifier, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            var staticStr = isStatic ? "static " : string.Empty;
            StringBuilder.AppendLine($"{LanguageSettings.GetIndent()}{LanguageSettings.GetAccessModifier(modifier)} {staticStr}{LanguageSettings.ClassKeyword} {className}{OpenBrace()}");
            LanguageSettings.IndentLevel++;
        }

        private string OpenBrace()
        {
            return LanguageSettings.BraceStyle == BraceStyle.EndOfLine ? " {" : "\r\n" + LanguageSettings.GetIndent() + "{";
        }
    }
}