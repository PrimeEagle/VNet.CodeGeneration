using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class PowerShellFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public PowerShellFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FieldScope), new List<string>() {} }, // PowerShell doesn't have specific modifiers for fields
            { typeof(AccessorScope), new List<string>() {"hidden", "static"} },
            { typeof(StructScope), new List<string>() {} }, // PowerShell does not natively support structs
            { typeof(EnumerationScope), new List<string>() {} }, // PowerShell doesn't have specific modifiers for enums
            { typeof(ClassScope), new List<string>() {"hidden", "static"} },
            { typeof(InterfaceScope), new List<string>() {} }, // PowerShell does not natively support interfaces
            { typeof(DelegateScope), new List<string>() {} }, // PowerShell does not natively support delegates
            { typeof(EventScope), new List<string>() {"hidden", "static"} },
            { typeof(FunctionScope), new List<string>() {"hidden", "static"} }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
            {
                // PowerShell does not disallow any specific combination of its modifiers
            };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ModuleScope),
                    typeof(CodeGroupingScope),
                    typeof(FunctionScope),
                    typeof(ClassScope)
                }
            },
            { typeof(CodeGroupingScope), new List<Type>()
                {
                    typeof(FunctionScope),
                    typeof(CommentScope),
                    typeof(CodeGroupingScope),
                    typeof(ClassScope)
                }
            },
            { typeof(ModuleScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FunctionScope),
                    typeof(ClassScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(EventScope),
                    typeof(FunctionScope),
                    typeof(AccessorScope),
                    typeof(CodeGroupingScope)
                }
            },
            { typeof(AccessorScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(CodeBlockScope)
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
            }
        };
        }
    }
}