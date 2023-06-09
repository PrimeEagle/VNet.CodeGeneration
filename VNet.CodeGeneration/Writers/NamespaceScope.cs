using System;
using System.Collections.Generic;
using System.Text;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers
{
    public class NamespaceScope : Scope
    {
        private readonly List<string> _usingStatements;

        public NamespaceScope(string namespaceName, StringBuilder sb, ILanguageSettings languageSettings)
            : base(sb, languageSettings)
        {
            StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.NamespaceKeyword} {namespaceName}{OpenBrace()}");
            LanguageSettings.Style.IndentLevel++;

            _usingStatements = new List<string>();
        }

        public NamespaceScope WithUsingStatement(string namespaceName)
        {
            if (!string.IsNullOrWhiteSpace(namespaceName) && LanguageSettings.Features.SupportsUsingStatements)
            {
                _usingStatements.Add(namespaceName);
            }
            return this;
        }

        public override void Dispose()
        {
            // Write using statements if supported
            if (LanguageSettings.Features.SupportsUsingStatements)
            {
                foreach (var usingStatement in _usingStatements)
                {
                    StringBuilder.AppendLine($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Keywords.UseStatementKeyword} {usingStatement};");
                }
            }

            base.Dispose();
        }

        private string OpenBrace()
        {
            return LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine ? " " + LanguageSettings.Style.OpenScope : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.OpenScope;
        }

        public ClassScope WithClass(string className, bool isStatic = false, AccessModifier modifier = AccessModifier.Public)
        {
            if (!LanguageSettings.Features.SupportsClasses)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support classes.");
            }

            var classScope = new ClassScope(className, isStatic, modifier, StringBuilder, LanguageSettings);
            return classScope;
        }

        public InterfaceScope WithInterface(string interfaceName, AccessModifier modifier = AccessModifier.Public)
        {
            if (!LanguageSettings.Features.SupportsInterfaces)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support interfaces.");
            }

            var interfaceScope = new InterfaceScope(interfaceName, modifier, StringBuilder, LanguageSettings);
            return interfaceScope;
        }

        public StructScope WithStruct(string structName, AccessModifier modifier = AccessModifier.Public)
        {
            if (!LanguageSettings.Features.SupportsStructs)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support structs.");
            }

            var structScope = new StructScope(structName, modifier, StringBuilder, LanguageSettings);
            return structScope;
        }

        public EnumScope WithEnum(string enumName, AccessModifier modifier = AccessModifier.Public)
        {
            if (!LanguageSettings.Features.SupportsEnums)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support enums.");
            }

            var enumScope = new EnumScope(enumName, modifier, StringBuilder, LanguageSettings);
            return enumScope;
        }

        public DelegateScope WithDelegate(string delegateName, string returnType, AccessModifier modifier = AccessModifier.Public, params (string type, string name)[] parameters)
        {
            if (!LanguageSettings.Features.SupportsDelegates)
            {
                throw new NotSupportedException($"{LanguageSettings.GetType().Name} does not support delegates.");
            }

            var delegateScope = new DelegateScope(delegateName, returnType, modifier, parameters, StringBuilder, LanguageSettings);
            return delegateScope;
        }
    }
}