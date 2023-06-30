using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CodeResult
    {
        public List<string> PreOpenScopeLines { get; set; }
        public List<string> PostOpenScopeLines { get; set; }
        public List<string> ScopedCodeLines { get; set; }
        public List<string> UnscopedCodeLines { get; set; }
        public string PreviousCodeLineSuffix { get; set; }
        public List<string> PostCloseScopeLines { get; set; }

        public CodeResult() 
        {
            PreOpenScopeLines = new List<string>();
            PostOpenScopeLines = new List<string>();
            ScopedCodeLines = new List<string>();
            UnscopedCodeLines = new List<string>();
            PostCloseScopeLines = new List<string>();
        }
    }
}