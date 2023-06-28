using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class BlockScope : Scope
    {
        protected BlockScope() : base()
        {

        }

        protected BlockScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {

        }

        internal override void GenerateCode()
        {
            OpenScope();

            WriteCodeLines();

            for (var s = 0; s < Scopes.Count; s++)
                Scopes[s].GenerateCode();

            CloseScope();
        }

        protected void OpenScope()
        {
            var result = LanguageSettings.StyledSyntax.GetOpenScope(IndentLevel.Current);

            AddOpenCodeResult(result);
        }

        protected void CloseScope()
        {
            var result = LanguageSettings.StyledSyntax.GetCloseScope(IndentLevel.Current);

            AddCloseCodeResult(result);
        }
    }
}