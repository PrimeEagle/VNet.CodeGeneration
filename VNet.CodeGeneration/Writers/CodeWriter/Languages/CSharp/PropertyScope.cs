﻿using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class PropertyScope : CSharpBlockScope<PropertyScope>
    {
        private string _returnType;
        private List<string> _modifiers;


        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.AccessorCaseConversionStyle;


        public PropertyScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
        }

        public GetterScope AddGetter(string name, int? value = null)
        {
            var result = new GetterScope(name, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public SetterScope AddSetter(string name, int? value = null)
        {
            var result = new SetterScope(name, new List<object>() { value }, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public PropertyScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public PropertyScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {       
            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";
            if (string.IsNullOrEmpty(_returnType)) _returnType = "void";
                       
            result.PreOpenScopeLines.Add($"{modifiers}{_returnType} {StyledValue}");
        }
    }
}