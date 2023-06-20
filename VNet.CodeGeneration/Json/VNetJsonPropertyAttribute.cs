using System;

namespace VNet.CodeGeneration.Json
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VNetJsonPropertyAttribute : Attribute
    {
        public string Name { get; }

        public VNetJsonPropertyAttribute(string name)
        {
            Name = name;
        }
    }
}
