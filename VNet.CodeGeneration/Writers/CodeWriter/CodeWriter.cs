using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class CodeWriter
    {
        public static CodeFile CreateCodeFile()
        {
            return new CodeFile();
        }
    }
}