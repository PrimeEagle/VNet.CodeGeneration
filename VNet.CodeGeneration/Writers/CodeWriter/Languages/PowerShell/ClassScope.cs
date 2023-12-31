﻿using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.PowerShell
{
    public class ClassScope : PowerShellBlockScope<ClassScope>
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ClassCaseConversionStyle;
        
        private string _baseClass;

        public ClassScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
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

        public PropertyScope AddProperty(string text)
        {
            var result = new PropertyScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public ClassScope DerivedFrom(string name)
        {
            _baseClass = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            if (!string.IsNullOrEmpty(_baseClass))
            {
                _baseClass = $"{spOp}:{spOp}{_baseClass}";
            }
            
            result.PreOpenScopeLines.Add($"class {StyledValue}{_baseClass}");
        }
    }
}