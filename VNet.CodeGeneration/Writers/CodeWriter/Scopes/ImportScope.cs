using System.Collections.Generic;
// ReSharper disable CollectionNeverUpdated.Local
// ReSharper disable MemberCanBePrivate.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class ImportScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;
        private ImportType _importType;


        internal ImportScope(string name, Scope parent)
            : base(name, parent)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
            Modifiers = new List<string>();
            _importType = ImportType.Module;
        }

        public ImportScope AddBlankLine()
        {
            _codeLines.Add(string.Empty);

            return this;
        }

        public ImportScope WithModifier(string modifier)
        {
            AddModifier(modifier);

            return this;
        }

        public ImportScope WithAccessModifier(AccessModifier accessModifier)
        {
            return WithAccessModifier(accessModifier.ToString());
        }

        public ImportScope WithAccessModifier(string accessModifier)
        {
            AddModifier(accessModifier);

            return this;
        }

        public ImportScope AsFile()
        {
            _importType = ImportType.File;

            return this;
        }

        public ImportScope AsModule()
        {
            _importType = ImportType.Module;

            return this;
        }

        public ImportScope AsAssembly()
        {
            _importType = ImportType.Assembly;

            return this;
        }

        public ImportScope AsGrouping()
        {
            _importType = ImportType.Grouping;

            return this;
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetImportStyledSyntax(StyledValue, _importType, Modifiers, IndentLevel));

            foreach (var childScope in _scopes)
                _codeLines.AddRange(childScope.GenerateCode());

            return _codeLines;
        }

        public override void Dispose()
        {
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetImportPostScopeStyledSyntax(StyledValue, _importType, Modifiers, IndentLevel));
        }
    }
}