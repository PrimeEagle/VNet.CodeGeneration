using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public sealed class UsingScope : Scope
    {
        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;

        internal UsingScope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
            : base(name, parent, languageSettings)
        {
            _codeLines = new List<string>();
            _scopes = new List<Scope>();
        }

        internal override List<string> GenerateCode()
        {
            _codeLines.Clear();



            return _codeLines;
        }
        //private readonly List<string> _codeLines;
        //private readonly string _namespace;

        //public UsingScope(string namespaceName, IProgrammingLanguageSettings languageSettings)
        //    : base(languageSettings)
        //{
        //    _namespace = namespaceName;
        //}

        //protected override string GenerateOpenScope()
        //{
        //    return "using ";
        //}

        //protected override string GenerateCloseScope()
        //{
        //    return string.Empty;
        //}
    }
}