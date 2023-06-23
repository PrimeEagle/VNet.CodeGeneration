using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Scopes;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.JavaScript
{
    public class JavaScriptFeatures : IProgrammingLanguageFeatures
    {
        public IDictionary<Type, IList<string>> AllowedModifiers { get; }
        public IDictionary<string, IList<string>> DisallowedModifierCombinations { get; }
        public IDictionary<Type, IList<Type>> ScopeContainmentRules { get; }

        public JavaScriptFeatures()
        {
            AllowedModifiers = new Dictionary<Type, IList<string>>()
        {
            { typeof(FieldScope), new List<string>() {"var", "let", "const"} },
            { typeof(FunctionScope), new List<string>() {"async"} },
            { typeof(VariableScope), new List<string>() {"var", "let", "const"} },
            { typeof(ClassScope), new List<string>() {"static"} }
        };

            DisallowedModifierCombinations = new Dictionary<string, IList<string>>()
        {
            { "var", new List<string>() {"let", "const"} },
            { "let", new List<string>() {"var", "const"} },
            { "const", new List<string>() {"var", "let"} }
        };

            ScopeContainmentRules = new Dictionary<Type, IList<Type>>()
        {
            { typeof(CodeFileScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FunctionScope),
                    typeof(ClassScope),
                    typeof(VariableScope)
                }
            },
            { typeof(FunctionScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope)
                }
            },
            { typeof(ClassScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(FieldScope),
                    typeof(FunctionScope)
                }
            },
            { typeof(CodeBlockScope), new List<Type>()
                {
                    typeof(CommentScope),
                    typeof(VariableScope),
                    typeof(CodeBlockScope)
                }
            }
        };
        }
    }
}