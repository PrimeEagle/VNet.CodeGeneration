using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Java
{
    public class ClassScope : JavaBlockScope<ClassScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;
        
        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<string> _genericConstraints;
        private List<string> _interfaces;
        private string _baseClass;

        public ClassScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
            _interfaces = new List<string>();
            _baseClass = string.Empty;
        }

        public ClassScope AddClass(string text)
        {
            var result = new ClassScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public MethodScope AddMethod()
        {
            return AddMethod(string.Empty);
        }

        public MethodScope AddMethod(string text)
        {
            var result = new MethodScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public EnumScope AddEnum(string text)
        {
            var result = new EnumScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public InterfaceScope AddInterface(string text)
        {
            var result = new InterfaceScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ClassScope DerivedFrom(string name)
        {
            _baseClass = name;

            return this;
        }

        public ClassScope ThatImplementsInterface(string name)
        {
            _interfaces.Add(name);

            return this;
        }

        public ClassScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public ClassScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        public ClassScope WithGenericConstraint(string name)
        {
            _genericConstraints.Add(name);

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var genConstraint = string.Join($"{spOp}&{spOp}", _genericConstraints).Trim();
            var gen = $"<{string.Join($",{spComma}", _genericTypes)} {genConstraint}>".Trim();


            var inheritance = $"extends {_baseClass}";
            var imp = $"{string.Join($",{spComma}", _interfaces)}".Trim();
            if (!string.IsNullOrEmpty(imp)) inheritance += $" implements {imp}";

            if (!string.IsNullOrEmpty(inheritance))
            {
                inheritance = $" {inheritance}";
            }
            
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}class {StyledValue}{gen}{inheritance}");
        }
    }
}