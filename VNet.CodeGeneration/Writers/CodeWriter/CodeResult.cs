using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public class CodeResult
    {
        public string PreviousLineSuffix { get; set; }
        public List<string> PostOpenScopeNewLines { get; set; }
        public string CloseScopeSuffix { get; set; }
        public List<string> PostCloseScopeNewLines { get; set; }

        public CodeResult() 
        {
            PostOpenScopeNewLines = new List<string>();
            PostCloseScopeNewLines = new List<string>();
        }
    }
}