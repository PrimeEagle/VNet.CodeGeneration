using System;
using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public interface IProgrammingLanguageFeatures
    {
        #region Comment Features
        bool SupportForSingleLineComments { get; }
        bool SupportForMultilineComments { get; }
        bool SupportForDocumentationComments { get; }
        #endregion Comment Feature

        IDictionary<Type, IList<string>> AllowedModifiers { get; }
        IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }
    }
}