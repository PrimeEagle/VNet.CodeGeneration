using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public CppFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FieldScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "static",
                    "const",
                    "volatile",
                    "mutable"
                }
            },
            { typeof(AccessorScope), new List<string>() {} }, // C++ does not have accessor scope
            { typeof(StructScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected"
                }
            },
            { typeof(EnumerationScope), new List<string>() {} }, // No specific modifiers for enums
            { typeof(ClassScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "virtual",
                    "friend"
                }
            },
            { typeof(InterfaceScope), new List<string>() {} }, // C++ does not have interface scope
            { typeof(DelegateScope), new List<string>() {} }, // C++ does not have delegate scope
            { typeof(EventScope), new List<string>() {} }, // C++ does not have event scope
            { typeof(FunctionScope), new List<string>()
                {
                    "public",
                    "private",
                    "protected",
                    "static",
                    "const",
                    "virtual",
                    "override",
                    "final"
                }
            }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
        {
            { "public", new List<string>()
                {
                    "private",
                    "protected"
                }
            },
            { "private", new List<string>()
                {
                    "public",
                    "protected"
                }
            },
            { "protected", new List<string>()
                {
                    "public",
                    "private"
                }
            },
            { "const", new List<string>()
                {
                    "volatile",
                    "mutable"
                }
            },
            { "volatile", new List<string>()
                {
                    "const"
                }
            },
            { "mutable", new List<string>()
                {
                    "const"
                }
            },
            { "static", new List<string>()
                {
                    "virtual"
                }
            },
            { "virtual", new List<string>()
                {
                    "static"
                }
            }
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ModuleScope),
                    typeof(ClassScope),
                    typeof(StructScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(ModuleScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ClassScope),
                    typeof(StructScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(ClassScope),
                    typeof(FunctionScope),
                    typeof(StructScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(FunctionScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeBlockScope)
                }
            },
            { typeof(CodeBlockScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope)
                }
            },
            { typeof(StructScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(ClassScope),
                    typeof(FunctionScope),
                    typeof(StructScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(EnumerationScope), new List<Type>()
                {
                    typeof(CommentScope)
                }
            }
        };
        }
    }
}