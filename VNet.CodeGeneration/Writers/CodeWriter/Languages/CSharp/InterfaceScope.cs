using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class InterfaceScope : CSharpBlockScope<InterfaceScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.InterfaceCaseConversionStyle;


        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<string> _genericConstraints;
        private List<string> _interfaces;

        public InterfaceScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
            _interfaces = new List<string>();
        }

        public InterfaceScope AddMethodSignature(string text)
        {
            var result = new MethodSignatureScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public PropertySignatureScope AddPropertySignature(string text)
        {
            var result = new PropertySignatureScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public InterfaceScope ThatImplementsInterface(string name)
        {
            _interfaces.Add(name);

            return this;
        }

        public InterfaceScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public InterfaceScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        public InterfaceScope WithGenericConstraint(string name)
        {
            _genericConstraints.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var opSpace = LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
            var commaSpace = LanguageSettings.Style.SpaceAfterComma ? " " : string.Empty;

            var genType = $"<{string.Join($",{commaSpace}", _genericTypes)}>".Trim();
            var genConstraint = string.Join($",{commaSpace}", _genericConstraints.Select(g => "where " + g).ToList()).Trim();

            var inheritance = $"{string.Join($",{commaSpace}", _interfaces)}".Trim();
            if (!string.IsNullOrEmpty(inheritance))
            {
                inheritance = $"{opSpace}:{opSpace}{inheritance}";
                genConstraint = $" {genConstraint}";
            }

            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}interface {StyledValue}{genType}{inheritance}{genConstraint}");
        }
    }
}