using System;

// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class CodeWriter
    {
        public static CodeFile CreateCodeFile()
        {
            return new CodeFile();
        }

        internal static string[] NewLineDelimiters => new string[]{ Environment.NewLine, "\r\n", "\r", "\n" };
    }
}