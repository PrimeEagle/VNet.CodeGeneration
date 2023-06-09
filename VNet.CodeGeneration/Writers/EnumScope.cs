using System;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class EnumScope : Scope
    {
        public EnumScope(string enumName, AccessModifier modifier, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetAccessModifier(modifier)} {LanguageSettings.Keywords.EnumKeyword} {enumName}{OpenBrace()}");
            LanguageSettings.Style.IndentLevel++;
        }

        private string OpenBrace()
        {
            return LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + LanguageSettings.Style.OpenScope : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.OpenScope;
        }

        public EnumScope WithAttribute(string attributeName, params string[] args)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}[{LanguageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public EnumScope WithDocumentationComment(string comment, CommentType commentType)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        public EnumScope WithValue(string value)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{value},");
            return this;
        }
    }
}