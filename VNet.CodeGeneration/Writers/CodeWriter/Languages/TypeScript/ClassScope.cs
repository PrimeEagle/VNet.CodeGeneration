using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp;

namespace VNet.Scientific.CodeGen.Writers.CodeWriter.Languages.TypeScript
{
    public class ClassScope : CSharpBlockScope<ClassScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;

        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<string> _interfaces;
        private string _baseClass;

        public ClassScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
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

        public CodeGeneration.Writers.CodeWriter.Languages.CSharp.EnumScope AddEnum(string text)
        {
            var result = new CodeGeneration.Writers.CodeWriter.Languages.CSharp.EnumScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public PropertyScope AddProperty(string text)
        {
            var result = new PropertyScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CodeGeneration.Writers.CodeWriter.Languages.CSharp.InterfaceScope AddInterface(string text)
        {
            var result = new CodeGeneration.Writers.CodeWriter.Languages.CSharp.InterfaceScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public StructScope AddStruct(string text)
        {
            var result = new StructScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
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

        protected override void WriteCode(CodeResult result)
        {
            var genType = $"<{string.Join($",{spComma}", _genericTypes)}>".Trim();

            var extends = !string.IsNullOrEmpty(_baseClass) ? $" extends {_baseClass}" : string.Empty;
            var implements = $"{string.Join($",{spComma}", _interfaces)}".Trim();
            if (!string.IsNullOrEmpty(implements))
            {
                implements = $" implements {implements}";
            }

            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            result.PreOpenScopeLines.Add($"{modifiers}class {StyledValue}{genType}{extends}{implements}");
        }
    }
}