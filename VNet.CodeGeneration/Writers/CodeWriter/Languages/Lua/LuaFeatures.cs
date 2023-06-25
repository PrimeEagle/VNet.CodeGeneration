using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Lua
{
    public class LuaFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public LuaFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(CodeFileScope), new List<string>() },
            { typeof(CodeBlockScope), new List<string>() },
            { typeof(FunctionScope), new List<string>() },
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>();

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeBlockScope),
                    typeof(FunctionScope)
                }
            },
            { typeof(CodeBlockScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeBlockScope),
                    typeof(FunctionScope)
                }
            },
            { typeof(FunctionScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeBlockScope)
                }
            }
        };
        }
    }
}