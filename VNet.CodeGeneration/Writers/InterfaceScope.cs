using System;
using System.Text;

namespace VNet.CodeGeneration.Writers
{
    public class InterfaceScope : Scope
    {
        public InterfaceScope(string interfaceName, AccessModifier modifier, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetAccessModifier(modifier)} {LanguageSettings.Keywords.InterfaceKeyword} {interfaceName}{OpenBrace()}");
            LanguageSettings.Style.IndentLevel++;
        }

        private string OpenBrace()
        {
            return LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + LanguageSettings.Style.OpenScope : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.OpenScope;
        }

        public MethodScope WithMethod(string methodName, string returnType, params (string type, string name)[] parameters)
        {
            if (!LanguageSettings.Features.SupportsMethods)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support methods.");
            }

            var methodScope = new MethodScope(methodName, returnType, false, AccessModifier.Public, parameters, StringBuilder, LanguageSettings);
            return methodScope;
        }

        public PropertyScope WithProperty(string propertyName, string propertyType, string getter = null, string setter = null)
        {
            if (!LanguageSettings.Features.SupportsProperties)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support properties.");
            }

            var propertyScope = new PropertyScope(propertyName, propertyType, false, AccessModifier.Public, getter, setter, StringBuilder, LanguageSettings);
            return propertyScope;
        }

        public InterfaceScope WithAttribute(string attributeName, params string[] args)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}[{LanguageSettings.Keywords.GetAttributeSyntax(attributeName, args)}]");
            return this;
        }

        public InterfaceScope WithDocumentationComment(string comment, CommentType commentType)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.GetCommentSyntax(comment, commentType)}");
            return this;
        }
    }
}