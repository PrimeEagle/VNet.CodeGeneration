using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public abstract class Scope
    {
        public IProgrammingLanguageSettings LanguageSettings { get; private set; }
        public string Name { get; private set; }
        public string StyledName => GetStyledName();
        public Scope Parent { get; private set; }


        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;


        protected Scope()
        {

        }

        protected Scope(string name, Scope parent, IProgrammingLanguageSettings languageSettings)
        {
            Name = name;
            LanguageSettings = languageSettings;
            Parent = parent;

            _scopes = new List<Scope>();
            _codeLines = new List<string>();
        }

        internal virtual List<string> GenerateCode()
        {
            _codeLines.Clear();

            _codeLines.AddRange(GenerateOpenScope());

            foreach (var childScope in _scopes)
            {
                _codeLines.AddRange(childScope.GenerateCode());
            }

            _codeLines.AddRange(GenerateCloseScope());

            return _codeLines;
        }

        private List<string> ExpandCodeLines(List<string> list)
        {
            var result = new List<string>();
            var delimiters = new string[] { Environment.NewLine, "\r\n", "\r", "\n" };


            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var line in list)
            {
                var sublines = line.Split(delimiters, StringSplitOptions.None);

                result.AddRange(sublines);
            }

            return result;
        }

        protected void AddNestedScope(Scope scope)
        {
            _scopes.Add(scope);
        }

        public virtual string Generate()
        {
            return ToString();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            GenerateCode();

            foreach (var splitLine in _codeLines.SelectMany(SplitLine))
            {
                result.Append(splitLine);
            }

            return result.ToString();
        }

        private List<string> SplitLine(string line)
        {
            var result = new List<string>() { line };

            if(!LanguageSettings.Style.BreakLongLines) return result;
            var maxLength = LanguageSettings.Style.MaxLineLength;

            if (line.Length <= maxLength) return result;
            result.Clear();
            var lineTooLong = true;
            var numPartials = 0;

            while (lineTooLong)
            {
                numPartials++;

                string partialLine;
                if (numPartials == 1)
                {
                    var idx = FindLineBreakIndex(line, maxLength);
                    partialLine = line.Substring(0, idx - 1);
                }
                else
                {
                    var idx = FindLineBreakIndex(line, maxLength - LanguageSettings.Style.LineBreakIndentationWidth);
                    partialLine = new string(' ', LanguageSettings.Style.LineBreakIndentationWidth) + line.Substring(0, idx - 1);
                }

                result.Add(partialLine);

                line = line.Substring(maxLength);
                lineTooLong = line.Length > maxLength;
            }

            return result;
        }

        private static int FindLineBreakIndex(string line, int maxIndex)
        {
            if (maxIndex > line.Length - 1) throw new ArgumentOutOfRangeException($"{nameof(maxIndex)} cannot be greater than the length of the string - 1.");

            var result = maxIndex;

            for (var i = maxIndex; i >= 0; i--)
            {
                if (char.IsWhiteSpace(line[i])) result = i;
                break;
            }
            
            return result;
        }

        public virtual void Dispose()
        {
            LanguageSettings.Style.IndentLevel--;
            _codeLines.Add($"{LanguageSettings.Style.GetIndent()}{LanguageSettings.Style.CloseScope}");
        }

        protected virtual void Dispose(bool disposing)
        {
            Dispose();
        }

        protected virtual List<string> GenerateOpenScope()
        {
            var result = new List<string>
            {
                LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + LanguageSettings.Style.OpenScope
                    : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.OpenScope
            };

            return result;
        }

        protected virtual List<string> GenerateCloseScope()
        {
            var result = new List<string>
            {
                LanguageSettings.Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + LanguageSettings.Style.CloseScope
                    : LanguageSettings.Style.LineBreakCharacter + LanguageSettings.Style.GetIndent() + LanguageSettings.Style.CloseScope
            };

            return result;
        }

        protected void ValidateScope(string name, Type childScopeType)
        {
            if (!(LanguageSettings.Syntax.ValidNaming(name) &&
                LanguageSettings.Features.ScopeContainmentRules.ContainsKey(this.GetType()) &&
                LanguageSettings.Features.ScopeContainmentRules[this.GetType()].Contains(childScopeType)))
            {
                throw new InvalidOperationException($"Creating a {childScopeType.Name} scope named '{name}' inside a {this.GetType().Name} scope is not allowed in {LanguageSettings.LanguageName}.");
            }
        }

        public virtual RegionScope AddRegion(string name)
        {
            ValidateScope(name, typeof(RegionScope));
            var newScope = new RegionScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual UsingScope AddUsingStatement(string name)
        {
            ValidateScope(name, typeof(UsingScope));
            var newScope = new UsingScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual NamespaceScope AddNamespace(string name)
        {
            ValidateScope(name, typeof(NamespaceScope));
            var newScope = new NamespaceScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual CommentScope AddComment(string name)
        {
            ValidateScope(name, typeof(CommentScope));
            var newScope = new CommentScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual EnumScope AddEnum(string name)
        {
            ValidateScope(name, typeof(EnumScope));
            var newScope = new EnumScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual StructScope AddStruct(string name)
        {
            ValidateScope(name, typeof(StructScope));
            var newScope = new StructScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual InterfaceScope AddInterface(string name)
        {
            ValidateScope(name, typeof(InterfaceScope));
            var newScope = new InterfaceScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual ClassScope AddClass(string name)
        {
            ValidateScope(name, typeof(ClassScope));
            var newScope = new ClassScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertyScope AddProperty(string name)
        {
            ValidateScope(name, typeof(PropertyScope));
            var newScope = new PropertyScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertyGetterScope AddPropertyGetter(string name)
        {
            ValidateScope(name, typeof(PropertyGetterScope));
            var newScope = new PropertyGetterScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertySetterScope AddPropertySetter(string name)
        {
            ValidateScope(name, typeof(PropertySetterScope));
            var newScope = new PropertySetterScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual ConstructorScope AddConstructor(string name)
        {
            ValidateScope(name, typeof(ConstructorScope));
            var newScope = new ConstructorScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual DelegateScope AddDelegate(string name)
        {
            ValidateScope(name, typeof(DelegateScope));
            var newScope = new DelegateScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual FieldScope AddField(string name)
        {
            ValidateScope(name, typeof(FieldScope));
            var newScope = new FieldScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual MethodScope AddMethod(string name)
        {
            ValidateScope(name, typeof(MethodScope));
            var newScope = new MethodScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual CodeBlockScope AddCodeBlock(string name)
        {
            ValidateScope(name, typeof(CodeBlockScope));
            var newScope = new CodeBlockScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual VariableScope AddVariable(string name)
        {
            ValidateScope(name, typeof(VariableScope));
            var newScope = new VariableScope(name, this, LanguageSettings);
            AddNestedScope(newScope);

            return newScope;
        }

        protected string GetStyledName()
        {
            var result = Name;

            if (!LanguageSettings.Style.EnableCaseConversion) return result;

            if (this is ClassScope) result = ConvertStyleCase(result, LanguageSettings.Style.ClassCaseConversionStyle);
            if (this is ConstructorScope) result = ConvertStyleCase(result, LanguageSettings.Style.ConstructorCaseConversionStyle);
            if (this is DelegateScope) result = ConvertStyleCase(result, LanguageSettings.Style.DelegateCaseConversionStyle);
            if (this is EnumScope) result = ConvertStyleCase(result, LanguageSettings.Style.EnumCaseConversionStyle);
            if (this is FieldScope) result = ConvertStyleCase(result, LanguageSettings.Style.FieldCaseConversionStyle);
            if (this is InterfaceScope) result = ConvertStyleCase(result, LanguageSettings.Style.InterfaceCaseConversionStyle);
            if (this is MethodScope) result = ConvertStyleCase(result, LanguageSettings.Style.MethodCaseConversionStyle);
            if (this is NamespaceScope) result = ConvertStyleCase(result, LanguageSettings.Style.NamespaceCaseConversionStyle);
            if (this is PropertyScope) result = ConvertStyleCase(result, LanguageSettings.Style.PropertyCaseConversionStyle);
            if (this is RegionScope) result = ConvertStyleCase(result, LanguageSettings.Style.RegionCaseConversionStyle);
            if (this is StructScope) result = ConvertStyleCase(result, LanguageSettings.Style.StructCaseConversionStyle);
            if (this is VariableScope) result = ConvertStyleCase(result, LanguageSettings.Style.VariableCaseConversionStyle);

            return result;
        }

        private static string ConvertStyleCase(string name, CaseConversionStyle conversionStyle)
        {
            string result;

            switch (conversionStyle)
            {
                case CaseConversionStyle.None:
                    result = name;
                    break;
                case CaseConversionStyle.AllLower:
                    result = ConvertCase.ToAlLLower(name);
                    break;
                case CaseConversionStyle.AllUpper:
                    result = ConvertCase.ToAllUpper(name);
                    break;
                case CaseConversionStyle.Pascal:
                    result = ConvertCase.ToPascal(name);
                    break;
                case CaseConversionStyle.Camel:
                    result = ConvertCase.ToCamel(name);
                    break;
                case CaseConversionStyle.Snake:
                    result = ConvertCase.ToSnake(name);
                    break;
                case CaseConversionStyle.Kebab:
                    result = ConvertCase.ToKebab(name);
                    break;
                case CaseConversionStyle.ScreamingSnake:
                    result = ConvertCase.ToScreamingSnake(name);
                    break;
                case CaseConversionStyle.ScreamingKebab:
                    result = ConvertCase.ToScreamingKebab(name);
                    break;
                case CaseConversionStyle.Title:
                    result = ConvertCase.ToTitle(name);
                    break;
                case CaseConversionStyle.TitleDot:
                    result = ConvertCase.ToTitleDot(name);
                    break;
                case CaseConversionStyle.LowerDot:
                    result = ConvertCase.ToLowerDot(name);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(conversionStyle), conversionStyle, null);
            }

            return result;
        }

        public virtual Scope Up()
        {
            return Parent;
        }
    }
}