using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public class CodeResult
    {
        public string PreOpenScope { get; set; }
        public List<string> InsideOpenScope { get; set; }
        public string PostOpenScope { get; set; }
        public List<string> ScopedCodeLines { get; set; }
        public List<string> UnscopedCodeLines { get; set; }
        public string PreCloseScope { get; set; }
        public List<string> InsideCloseScope { get; set; }
        public string PostCloseScope { get; set; }


        public CodeResult() 
        {
            InsideOpenScope = new List<string>();
            ScopedCodeLines = new List<string>();
            UnscopedCodeLines = new List<string>();
            InsideCloseScope = new List<string>();
        }
    }
}