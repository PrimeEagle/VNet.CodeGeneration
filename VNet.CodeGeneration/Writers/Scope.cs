using System;
using System.Text;

namespace VNet.Scientific.CodeGen.Writers
{
    public class Scope : IDisposable
    {
        protected readonly StringBuilder StringBuilder;
        protected readonly ILanguageSettings LanguageSettings;

        public Scope(StringBuilder sb, ILanguageSettings languageSettings)
        {
            StringBuilder = sb;
            LanguageSettings = languageSettings;
        }

        public virtual void Dispose()
        {
            LanguageSettings.IndentLevel--;
            StringBuilder.AppendLine($"{LanguageSettings.GetIndent()}{LanguageSettings.CloseScope}");
        }
    }
}