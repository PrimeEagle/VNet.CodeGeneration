using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class TypeScriptFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }


        public TypeScriptFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FieldScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "static",
                    "readonly",
                }
            },
            { typeof(AccessorScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                }
            },
            { typeof(ClassScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "static",
                }
            },
            { typeof(InterfaceScope), new List<string>(){} // No modifiers in TypeScript Interfaces
            },
            { typeof(FunctionScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "static",
                    "readonly",
                    "async",
                }
            }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
        {
            { "public", new List<string>()
                {
                    "private",
                    "protected",
                }
            },
            { "private", new List<string>()
                {
                    "public",
                    "protected",
                }
            },
            { "protected", new List<string>()
                {
                    "private",
                    "public",
                }
            },
            { "static", new List<string>()
                {
                    "readonly",
                }
            },
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ImportScope),
                    typeof(ModuleScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(ModuleScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ImportScope),
                    typeof(ClassScope),
                    typeof(InterfaceScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(ClassScope),
                    typeof(InterfaceScope),
                    typeof(FunctionScope),
                    typeof(AccessorScope),
                    typeof(CodeGroupingScope)
                }
            },
            {
                typeof(AccessorScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(GetterScope),
                    typeof(SetterScope),
                    typeof(CodeGroupingScope)
                }
            },
            {
                typeof(GetterScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeGroupingScope)
                }
            },
            {
                typeof(SetterScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(FunctionScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(CodeBlockScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(InterfaceScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FunctionScope),
                    typeof(AccessorScope),
                    typeof(CodeGroupingScope)
                }
            },
        };
        }
    }
}
