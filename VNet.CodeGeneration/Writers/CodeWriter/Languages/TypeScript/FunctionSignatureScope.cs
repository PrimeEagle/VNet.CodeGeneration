﻿using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Writers.CodeWriter;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.TypeScript
{
    public class FunctionSignatureScope : TypeScriptLineScope<FunctionSignatureScope>
    {
        private string _returnType;
        private List<string> _modifiers;
        private List<string> _genericTypes;
        private List<string> _genericConstraints;
        private List<Tuple<string, string>> _parameters;

        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.FunctionCaseConversionStyle;


        public FunctionSignatureScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {
            _modifiers = new List<string>();
            _genericTypes = new List<string>();
            _genericConstraints = new List<string>();
            _parameters = new List<Tuple<string, string>>();
        }

        public FunctionSignatureScope WithModifier(string name)
        {
            _modifiers.Add(name);

            return this;
        }

        public FunctionSignatureScope WithGenericType(string name)
        {
            _genericTypes.Add(name);

            return this;
        }

        public FunctionSignatureScope WithGenericConstraint(string name)
        {
            _genericConstraints.Add(name);

            return this;
        }

        public FunctionSignatureScope WithParameter(string type, string name)
        {
            _parameters.Add(new Tuple<string, string>(type, name));

            return this;
        }

        public FunctionSignatureScope WithReturnType(string name)
        {
            _returnType = name;

            return this;
        }

        protected override void WriteCode(CodeResult result)
        {
            var genType = $"<{string.Join($",{spComma}", _genericTypes)}>".Trim();
            if (genType.Length <= 2) genType = string.Empty;

            var genConstraint = string.Join($",{spComma}", _genericConstraints.Select(g => "where " + g).ToList()).Trim();

            _modifiers.Add(_returnType);
            var modifiers = string.Join(" ", _modifiers).Trim();
            if (!string.IsNullOrEmpty(modifiers)) modifiers += " ";

            var flattened = _parameters.Select(p => $"{p.Item1} {p.Item2}").ToList();
            var paramStr = string.Join($",{spComma}", flattened).Trim();

            result.PreOpenScopeLines.Add($"{modifiers}{StyledValue}{genType}({paramStr}){genConstraint};");
        }
    }
}