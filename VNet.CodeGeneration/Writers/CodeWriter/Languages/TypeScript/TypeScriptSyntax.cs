using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptSyntax : IProgrammingLanguageSyntax
    {
        public string OpenScopeSymbol => "{";
        public string CloseScopeSymbol => "}";
        

        public bool IsValidNaming(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}