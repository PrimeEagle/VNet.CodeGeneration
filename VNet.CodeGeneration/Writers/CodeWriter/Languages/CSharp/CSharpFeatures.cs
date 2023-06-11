using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpFeatures : IProgrammingLanguageFeatureSettings
    {
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }


        public CSharpFeatures()
        {
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
                        typeof(ConstructorScope),
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
                        typeof(ConstructorScope),
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
                }
            };
        }
    }
}