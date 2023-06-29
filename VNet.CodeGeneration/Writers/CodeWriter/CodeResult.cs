using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CodeResult
    {
        public List<string> OpenScopeLines { get; set; }
        public List<string> ScopeCodeLines { get; set; }
        public List<string> UnscopedCodeLines { get; set; }
        public string PreviousCodeLineSuffix { get; set; }
        public List<string> CloseScopeLines { get; set; }

        public CodeResult() 
        {
            OpenScopeLines = new List<string>();
            ScopeCodeLines = new List<string>();
            UnscopedCodeLines = new List<string>();
            CloseScopeLines = new List<string>();
        }
    }
}