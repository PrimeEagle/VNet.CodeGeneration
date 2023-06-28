//using System;
//using System.Collections.Generic;
//using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

//namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
//{
//    public class CSharpFeatures : IProgrammingLanguageFeatures
//    {
//        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
//        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
//        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }


//        public CSharpFeatures()
//        {
//            AllowedModifiers = new Dictionary<Type, IList<string>>()
//            {
//                { typeof(AccessorScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "static",
//                        "readonly",
//                        "const",
//                        "volatile",
//                        "new",
//                        "virtual",
//                        "abstract",
//                        "override"
//                    }
//                },
//                { typeof(StructScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "static",
//                        "readonly",
//                        "const",
//                        "volatile"
//                    }
//                },
//                { typeof(EnumerationScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "static",
//                        "readonly",
//                        "const",
//                        "volatile"
//                    }
//                },
//                { typeof(ClassScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "static",
//                        "readonly",
//                        "const",
//                        "volatile",
//                        "new",
//                        "virtual",
//                        "abstract",
//                        "override",
//                        "sealed",
//                        "partial"
//                    }
//                },
//                { typeof(InterfaceScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "partial"
//                    }
//                },
//                { typeof(FunctionScope), new List<string>()
//                    {
//                        "public",
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected",
//                        "static",
//                        "readonly",
//                        "const",
//                        "volatile",
//                        "new",
//                        "virtual",
//                        "abstract",
//                        "override",
//                        "async",
//                        "sealed",
//                        "partial",
//                        "extern"
//                    }
//                }
//            };

//            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
//            {
//                { "public", new List<string>()
//                    {
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected"
//                    }
//                },
//                { "private", new List<string>()
//                    {
//                        "public",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "private protected"
//                    }
//                },
//                { "internal", new List<string>()
//                    {
//                        "private",
//                        "public",
//                        "protected",
//                        "protected internal",
//                        "private protected"
//                    }
//                },
//                { "protected", new List<string>()
//                    {
//                        "private",
//                        "internal",
//                        "public",
//                        "protected internal",
//                        "private protected"
//                    }
//                },
//                { "protected internal", new List<string>()
//                    {
//                        "private",
//                        "internal",
//                        "protected",
//                        "public",
//                        "private protected"
//                    }
//                },
//                { "private protected", new List<string>()
//                    {
//                        "private",
//                        "internal",
//                        "protected",
//                        "protected internal",
//                        "public"
//                    }
//                },
//                { "readonly", new List<string>()
//                    {
//                        "const",
//                        "volatile"
//                    }
//                },
//                { "const", new List<string>()
//                    {
//                        "readonly",
//                        "volatile",
//                    }
//                },
//                { "volatile", new List<string>()
//                    {
//                        "readonly",
//                        "const"
//                    }
//                },
//                { "abstract", new List<string>()
//                    {
//                        "virtual",
//                        "override",
//                        "new",
//                        "sealed"
//                    }
//                },
//                { "override", new List<string>()
//                    {
//                        "abstract",
//                        "virtual",
//                        "new"
//                    }
//                },
//                { "new", new List<string>()
//                    {
//                        "virtual",
//                        "override",
//                        "abstract"
//                    }
//                },

//                { "sealed", new List<string>()
//                    {
//                        "virtual",
//                        "abstract"
//                    }
//                }
//            };

//            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
//            {
//                { typeof(CodeFileScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(ImportScope),
//                        typeof(ModuleScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(CodeGroupingScope), new List<Type>()
//                    {
//                        typeof(ClassScope),
//                        typeof(CodeBlockScope),
//                        typeof(CommentScope),
//                        typeof(DelegateScope),
//                        typeof(EnumerationScope),
//                        typeof(FieldScope),
//                        typeof(InterfaceScope),
//                        typeof(FunctionScope),
//                        typeof(ModuleScope),
//                        typeof(GetterScope),
//                        typeof(AccessorScope),
//                        typeof(SetterScope),
//                        typeof(CodeGroupingScope),
//                        typeof(StructScope),
//                        typeof(ImportScope),
//                        typeof(VariableScope)
//                    }
//                },
//                { typeof(ModuleScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(ImportScope),
//                        typeof(ClassScope),
//                        typeof(EnumerationScope),
//                        typeof(InterfaceScope),
//                        typeof(StructScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(ClassScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(CodeBlockScope),
//                        typeof(FieldScope),
//                        typeof(ClassScope),
//                        typeof(InterfaceScope),
//                        typeof(FunctionScope),
//                        typeof(AccessorScope),
//                        typeof(StructScope),
//                        typeof(DelegateScope),
//                        typeof(EventScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                {
//                    typeof(AccessorScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(GetterScope),
//                        typeof(SetterScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                {
//                    typeof(GetterScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(VariableScope),
//                        typeof(CodeBlockScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                {
//                    typeof(SetterScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(VariableScope),
//                        typeof(CodeBlockScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(FunctionScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(DelegateScope),
//                        typeof(EventScope),
//                        typeof(VariableScope),
//                        typeof(CodeBlockScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(CodeBlockScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(VariableScope),
//                        typeof(CodeBlockScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(StructScope), new List<Type>()
//                    {
//                        typeof(CommentScope),
//                        typeof(FieldScope),
//                        typeof(ClassScope),
//                        typeof(InterfaceScope),
//                        typeof(FunctionScope),
//                        typeof(AccessorScope),
//                        typeof(StructScope),
//                        typeof(DelegateScope),
//                        typeof(EventScope),
//                        typeof(CodeGroupingScope)
//                    }
//                },
//                { typeof(EnumerationScope), new List<Type>()
//                    {
//                        typeof(CommentScope)
//                    }
//                },
//                { typeof(CommentScope), new List<Type>() }
//            };
//        }
//    }
//}