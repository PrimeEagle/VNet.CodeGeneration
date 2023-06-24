using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.C
{
    public class CFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public CFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FieldScope), new List<string>() { "static", "const", "volatile", "extern" } },
            { typeof(StructScope), new List<string>() { "typedef" } },
            { typeof(EnumerationScope), new List<string>() { "typedef" } },
            { typeof(FunctionScope), new List<string>() { "static", "extern", "inline" } }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
        {
            { "const", new List<string>() { "volatile" } },
            { "volatile", new List<string>() { "const" } }
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>() { typeof(CommentScope), typeof(ImportScope), typeof(FunctionScope), typeof(StructScope), typeof(EnumerationScope) } },
            { typeof(StructScope), new List<Type>() { typeof(FieldScope) } },
            { typeof(FunctionScope), new List<Type>() { typeof(VariableScope), typeof(CodeBlockScope), typeof(CommentScope) } },
            { typeof(CodeBlockScope), new List<Type>() { typeof(VariableScope), typeof(CodeBlockScope), typeof(CommentScope) } },
            { typeof(EnumerationScope), new List<Type>() { typeof(CommentScope) } }
        };
        }
    }
}