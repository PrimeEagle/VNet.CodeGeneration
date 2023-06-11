using System;
using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageFeatureSettings
    {
        IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }
    }
}