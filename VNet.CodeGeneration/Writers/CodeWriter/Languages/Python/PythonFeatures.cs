using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }


        public PythonFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FunctionScope), new List<string>()
                {
                    "@staticmethod",
                    "@classmethod",
                    "@abstractmethod",
                    "@property",
                    "@decorator",
                }
            },
            { typeof(ClassScope), new List<string>()
                {
                    ""
                }
            }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
        {
            { "@staticmethod", new List<string>()
                {
                    "@classmethod",
                    "@abstractmethod",
                    "@property"
                }
            },
            { "@classmethod", new List<string>()
                {
                    "@staticmethod",
                    "@abstractmethod",
                    "@property"
                }
            },
            { "@abstractmethod", new List<string>()
                {
                    "@staticmethod",
                    "@classmethod",
                    "@property"
                }
            },
            { "@property", new List<string>()
                {
                    "@staticmethod",
                    "@classmethod",
                    "@abstractmethod"
                }
            }
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ModuleScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(ModuleScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ClassScope),
                    typeof(FunctionScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FunctionScope),
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
            { typeof(CodeGroupingScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope),
                    typeof(CodeGroupingScope)
                }
            }
        };
        }
    }

}