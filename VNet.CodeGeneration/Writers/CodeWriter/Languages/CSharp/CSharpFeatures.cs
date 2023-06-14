using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }


        public CSharpFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
            {
                { typeof(FieldScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile",
                        "new"
                    }
                },
                { typeof(PropertyScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile",
                        "new",
                        "virtual",
                        "abstract",
                        "override"
                    }
                },
                { typeof(StructScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile"
                    }
                },
                { typeof(EnumScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile"
                    }
                },
                { typeof(ClassScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile",
                        "new",
                        "virtual",
                        "abstract",
                        "override",
                        "sealed",
                        "partial"
                    }
                },
                { typeof(InterfaceScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "partial"
                    }
                },
                { typeof(DelegateScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static"
                    }
                },
                { typeof(EventScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "virtual",
                        "override",
                        "abstract",
                        "extern",
                        "sealed"
                    }
                },
                { typeof(MethodScope), new List<string>()
                    {
                        "public",
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected",
                        "static",
                        "readonly",
                        "const",
                        "volatile",
                        "new",
                        "virtual",
                        "abstract",
                        "override",
                        "async",
                        "sealed",
                        "partial",
                        "extern"
                    }
                }
            };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
            {
                { "public", new List<string>()
                    {
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected"
                    }
                },
                { "private", new List<string>()
                    {
                        "public",
                        "internal",
                        "protected",
                        "protected internal",
                        "private protected"
                    }
                },
                { "internal", new List<string>()
                    {
                        "private",
                        "public",
                        "protected",
                        "protected internal",
                        "private protected"
                    }
                },
                { "protected", new List<string>()
                    {
                        "private",
                        "internal",
                        "public",
                        "protected internal",
                        "private protected"
                    }
                },
                { "protected internal", new List<string>()
                    {
                        "private",
                        "internal",
                        "protected",
                        "public",
                        "private protected"
                    }
                },
                { "private protected", new List<string>()
                    {
                        "private",
                        "internal",
                        "protected",
                        "protected internal",
                        "public"
                    }
                },
                { "readonly", new List<string>()
                    {
                        "const",
                        "volatile"
                    }
                },
                { "const", new List<string>()
                    {
                        "readonly",
                        "volatile",
                    }
                },
                { "volatile", new List<string>()
                    {
                        "readonly",
                        "const"
                    }
                },
                { "abstract", new List<string>()
                    {
                        "virtual",
                        "override",
                        "new",
                        "sealed"
                    }
                },
                { "abstract", new List<string>()
                    {
                        "virtual",
                        "override",
                        "new",
                        "sealed"
                    }
                },
                { "override", new List<string>()
                    {
                        "abstract",
                        "virtual",
                        "new"
                    }
                },
                { "new", new List<string>()
                    {
                        "virtual",
                        "override",
                        "abstract"
                    }
                },

                { "sealed", new List<string>()
                    {
                        "virtual",
                        "abstract"
                    }
                }
            };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
            {
                { typeof(CodeFile), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(UsingScope),
                        typeof(NamespaceScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(RegionScope), new List<Type>()
                    {
                        typeof(ClassScope),
                        typeof(CodeBlockScope),
                        typeof(CommentScope),
                        typeof(DelegateScope),
                        typeof(EnumScope),
                        typeof(FieldScope),
                        typeof(InterfaceScope),
                        typeof(MethodScope),
                        typeof(NamespaceScope),
                        typeof(PropertyGetterScope),
                        typeof(PropertyScope),
                        typeof(PropertySetterScope),
                        typeof(RegionScope),
                        typeof(StructScope),
                        typeof(UsingScope),
                        typeof(VariableScope)
                    }
                },
                { typeof(NamespaceScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(UsingScope),
                        typeof(ClassScope),
                        typeof(EnumScope),
                        typeof(InterfaceScope),
                        typeof(StructScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(ClassScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(FieldScope),
                        typeof(ClassScope),
                        typeof(InterfaceScope),
                        typeof(MethodScope),
                        typeof(PropertyScope),
                        typeof(StructScope),
                        typeof(DelegateScope),
                        typeof(EventScope),
                        typeof(RegionScope)
                    }
                },
                {
                    typeof(PropertyScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(PropertyGetterScope),
                        typeof(PropertySetterScope),
                        typeof(RegionScope)
                    }
                },
                {
                    typeof(PropertyGetterScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(VariableScope),
                        typeof(CodeBlockScope),
                        typeof(RegionScope)
                    }
                },
                {
                    typeof(PropertySetterScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(VariableScope),
                        typeof(CodeBlockScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(MethodScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(DelegateScope),
                        typeof(EventScope),
                        typeof(VariableScope),
                        typeof(CodeBlockScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(CodeBlockScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(VariableScope),
                        typeof(CodeBlockScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(StructScope), new List<Type>()
                    {
                        typeof(CommentScope),
                        typeof(FieldScope),
                        typeof(ClassScope),
                        typeof(InterfaceScope),
                        typeof(MethodScope),
                        typeof(PropertyScope),
                        typeof(StructScope),
                        typeof(DelegateScope),
                        typeof(EventScope),
                        typeof(RegionScope)
                    }
                },
                { typeof(EnumScope), new List<Type>()
                    {
                        typeof(CommentScope)
                    }
                }
            };
        }
    }
}