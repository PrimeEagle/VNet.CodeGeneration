using System;
using System.Collections.Generic;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.Python
{
    public class PythonStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public PythonStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
        {
            Syntax = syntax;
            Style = style;
        }

        public string GetSingleIndentCode()
        {
            return GetIndentCode(1);
        }

        public string GetIndentCode(int numberOfIndents)
        {
            var indent = Style.UseSpacesForIndentation ? new string(' ', Style.IndentationWidth) : "\t";
            return string.Concat(Enumerable.Repeat(indent, numberOfIndents));
        }

        public IEnumerable<string> GetOpenScope(int currentIndentLevel)
        {
            return new List<string>(); // Python does not have explicit scope opening
        }

        public IEnumerable<string> GetCloseScope(int currentIndentLevel)
        {
            return new List<string>(); // Python does not have explicit scope closing
        }

        public IEnumerable<string> GetCodeGroupingOpenScope(string styledValue, int currentIndentLevel)
        {
            return new List<string>() { $"{GetIndentCode(currentIndentLevel)}{styledValue}" };
        }

        public IEnumerable<string> GetCodeGroupingCloseScope(string styledValue, int currentIndentLevel)
        {
            return new List<string>() { $"{GetIndentCode(currentIndentLevel)}{styledValue}" };
        }

        public IEnumerable<string> GetModuleStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ModuleStyle namespaceStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}{Syntax.ModuleKeyword} {styledValue}"
        };
            return codeLines;
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentStyle commentStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}# {styledValue}"
        };
            return codeLines;
        }

        public IEnumerable<string> GetImportStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ImportStyle importStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}{Syntax.ImportKeyword} {styledValue}"
        };
            return codeLines;
        }

        public IEnumerable<string> GetEnumerationStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, EnumerationStyle enumerationStyle)
        {
            // Not exactly same as C# Enum, but we can use Python classes to simulate it
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}class {styledValue}:"
        };
            return codeLines;
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, StructStyle structStyle)
        {
            throw new NotImplementedException("Python does not have an exact equivalent of C# struct.");
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, InterfaceStyle interfaceStyle)
        {
            throw new NotImplementedException("Python does not have an interface keyword.");
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, ClassStyle classStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}class {styledValue}:"
        };
            return codeLines;
        }

        public IEnumerable<string> GetDelegateStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, DelegateStyle delegateStyle)
        {
            throw new NotImplementedException("Python does not have an exact equivalent of C# delegate.");
        }

        public IEnumerable<string> GetEventStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, EventStyle eventStyle)
        {
            throw new NotImplementedException("Python does not have an exact equivalent of C# events.");
        }

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, FunctionStyle functionStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}def {styledValue}:"
        };
            return codeLines;
        }

        public IEnumerable<string> GetFieldStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, FieldStyle fieldStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}{styledValue}"
        };
            return codeLines;
        }

        public IEnumerable<string> GetVariableStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, VariableStyle variableStyle)
        {
            var codeLines = new List<string>
        {
            $"{GetIndentCode(indentLevel.Current)}{styledValue}"
        };
            return codeLines;
        }

        public IEnumerable<string> GetAccessorStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, AccessorStyle accessorStyle)
        {
            throw new NotImplementedException("Python does not have an accessor keyword.");
        }

        public IEnumerable<string> GetGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, GetterStyle getterStyle)
        {
            throw new NotImplementedException("Python does not have a getter keyword.");
        }

        public IEnumerable<string> GetSetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, SetterStyle setterStyle)
        {
            throw new NotImplementedException("Python does not have a setter keyword.");
        }
    }

}