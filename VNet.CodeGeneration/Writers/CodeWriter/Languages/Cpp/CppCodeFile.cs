﻿using System.Collections.Generic;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Cpp
{
    public class CppCodeFile : CppBlockScope<CppCodeFile>, IProgrammingLanguageCodeFile
    {
        protected override CaseConversionStyle CaseConversionStyle => CaseConversionStyle.None;
        protected override string AlternateScopeOpenSymbol => string.Empty;
        protected override string AlternateScopeCloseSymbol => string.Empty;

        protected CppCodeFile(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
    : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        { }

        public static CppCodeFile Create()
        {
            return new CppCodeFile(null, null, new CppLanguageSettings(new CppDefaultStyle()), null, new IndentationManager(), new List<string>());
        }

        public CppCodeFile WithStyle(IProgrammingLanguageStyle style)
        {
            LanguageSettings.Style = style;

            return this;
        }

        public NamespaceScope AddNamespace(string name)
        {
            var result = new NamespaceScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CppCodeFile AddUsing(string name)
        {
            var result = new UsingScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CppCodeFile AddInclude(string name)
        {
            var result = new IncludeScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CppCodeFile AddTypeTemplate(string name)
        {
            var result = new TypeTemplateScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public ClassScope AddClass(string name)
        {
            var result = new ClassScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public MethodScope AddFunction(string name)
        {
            var result = new MethodScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CppCodeFile AddFunctionSignature(string name)
        {
            var result = new MethodSignatureScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public StructScope AddStruct(string name)
        {
            var result = new StructScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public EnumScope AddEnum(string name)
        {
            var result = new EnumScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCode(CodeResult result)
        {
            return;
        }
    }
}