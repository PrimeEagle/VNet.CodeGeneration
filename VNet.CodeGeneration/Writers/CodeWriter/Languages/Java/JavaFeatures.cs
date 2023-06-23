using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class JavaFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public JavaFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(ClassScope), new List<string>()
                {
                    "public",
                    "protected",
                    "private",
                    "abstract",
                    "static",
                    "final"
                }
            },
            { typeof(InterfaceScope), new List<string>()
                {
                    "public",
                    "protected",
                    "private",
                    "abstract",
                    "static",
                    "strictfp"
                }
            },
            { typeof(FunctionScope), new List<string>()
                {
                    "public",
                    "protected",
                    "private",
                    "abstract",
                    "static",
                    "final",
                    "native",
                    "synchronized"
                }
            },
            { typeof(FieldScope), new List<string>()
                {
                    "public",
                    "protected",
                    "private",
                    "static",
                    "final",
                    "transient",
                    "volatile"
                }
            },
            { typeof(EnumerationScope), new List<string>()
                {
                    "public",
                    "protected",
                    "private",
                    "static",
                    "strictfp"
                }
            },
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
                    "private",
                    "public"
                }
            },
            { "final", new List<string>()
                {
                    "abstract"
                }
            },
            { "abstract", new List<string>()
                {
                    "final",
                    "private",
                    "static"
                }
            },
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(ImportScope),
                    typeof(ClassScope),
                    typeof(InterfaceScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(FunctionScope),
                    typeof(ClassScope),
                    typeof(InterfaceScope),
                    typeof(EnumerationScope)
                }
            },
            { typeof(InterfaceScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(FunctionScope),
                    typeof(InterfaceScope)
                }
            },
            { typeof(FunctionScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(FunctionScope)
                }
            },
        };
        }
    }

}