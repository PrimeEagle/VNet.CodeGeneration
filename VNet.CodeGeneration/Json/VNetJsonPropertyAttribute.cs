using System;
using System.Collections.Generic;
using System.Text;

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
