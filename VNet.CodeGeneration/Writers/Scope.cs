using System;
using System.Text;

namespace VNet.CodeGeneration.Writers
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
            LanguageSettings.Style.IndentLevel--;
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Style.CloseScope}");
        }

        protected virtual void Dispose(bool disposing)
        {
            Dispose();
        }
    }
}