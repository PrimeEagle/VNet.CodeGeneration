using System;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class StructScope : ClassScope
    {
        public StructScope(string structName, AccessModifier modifier, StringBuilder sb, ILanguageSettings languageSettings)
            : base(structName, false, modifier, sb, languageSettings)
        {
            StringBuilder.Clear();  // Clear the output of the base constructor
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetAccessModifier(modifier)} {LanguageSettings.Keywords.StructKeyword} {structName}{OpenBrace()}");
        }

        public StructScope WithAttribute(string attributeName, params string[] args)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}[{LanguageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public StructScope WithDocumentationComment(string comment, CommentType commentType)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }

        private string OpenBrace()
        {
            return LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + LanguageSettings.Style.OpenScope : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.OpenScope;
        }
    }
}