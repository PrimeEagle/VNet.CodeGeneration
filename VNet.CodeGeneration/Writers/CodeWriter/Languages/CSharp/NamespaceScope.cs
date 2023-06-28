using System;
using System.Collections.Generic;
using VNet.CodeGeneration.Writers.CodeWriter.Languages.Common;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class NamespaceScope : IndentedBlockScope
    {
        protected override CaseConversionStyle CaseConversionStyle => LanguageSettings.Style.ImportCaseConversionStyle;


        internal NamespaceScope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
            : base(value, parameters, languageSettings, parent, indentLevel, codeLines)
        {

        }

        public NamespaceScope AddBlankLine()
        {
            var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public NamespaceScope AddBlankLines(int num)
        {
            for (int i = 0; i < num; i++)
            {
                var result = new BlankLineScope(null, null, LanguageSettings, this, IndentLevel, CodeLines);
                AddNestedScope(result);
            }

            return this;
        }

        public NamespaceScope AddCodeLine(string text)
        {
            var result = new CodeLineScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CodeBlockScope AddCodeBlock(string text)
        {
            var result = new CodeBlockScope(text, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public NamespaceScope AddUsing(string name)
        {
            var result = new UsingScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public ClassScope AddClass(string name)
        {
            var result = new ClassScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public InterfaceScope AddInterface(string name)
        {
            var result = new InterfaceScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
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

        public RegionScope AddRegion(string name)
        {
            var result = new RegionScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public NamespaceScope AddComment(string name)
        {
            var result = new CommentSingleLineScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return this;
        }

        public CommentMultiLineScope AddMultiLineComment(string name)
        {
            var result = new CommentMultiLineScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        public CommentDocumentationScope AddDocumentationComment(string name)
        {
            var result = new CommentDocumentationScope(name, null, LanguageSettings, this, IndentLevel, CodeLines);
            AddNestedScope(result);

            return result;
        }

        protected override void WriteCodeLines()
        {
            CodeLines.Add($"{GetIndent(IndentLevel.Current)}namespace {StyledValue}");
        }
    }
}
