using System;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class CodeWriter
    {
        public static T For<T>() where T : class, IProgrammingLanguageCodeFile
        {
            return (T)Activator.CreateInstance(typeof(T), true);
        }
    }
}