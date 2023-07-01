using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        

        public bool IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}