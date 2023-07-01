using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
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