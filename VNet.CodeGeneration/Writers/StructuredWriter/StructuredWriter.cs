using System;

namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public static class StructuredWriter
    {
        public static T For<T>() where T : class, IStructuredLanguageCodeFile
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}