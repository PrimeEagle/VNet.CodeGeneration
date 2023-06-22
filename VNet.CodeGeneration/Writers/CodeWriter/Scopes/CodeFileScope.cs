using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable NotAccessedField.Local
#pragma warning disable IDE0052


namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CodeFileScope : Scope
    {
        private readonly List<string> _codeLines;
        private readonly List<Scope> _scopes;
        private IProgrammingLanguageSettings _languageSettings;


        internal CodeFileScope()
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            IndentLevel = new IndentationManager();
        }

        public CodeFileScope UsingLanguageSettings(IProgrammingLanguageSettings languageSettings)
        {
            _languageSettings = languageSettings;

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();

            return _codeLines;
        }

        public override Scope Up()
        {
            throw new InvalidOperationException("CodeFile has no parent.");
        }
    }
}