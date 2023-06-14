using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedMember.Local
#pragma warning disable IDE0051

namespace VNet.CodeGeneration.Writers.CodeWriter.Scopes
{
    public abstract class Scope
    {
        public IProgrammingLanguageSettings LanguageSettings { get; private set; }
        public string Value { get; private set; }
        public string StyledValue => GetStyledValue();
        public Scope Parent { get; private set; }
        protected IndentationManager IndentLevel { get; set; }
        protected List<string> Modifiers;
        protected int SortOrder;


        private readonly List<Scope> _scopes;
        private readonly List<string> _codeLines;


        protected Scope()
        {
            IndentLevel = new IndentationManager();
            _scopes = new List<Scope>();
            _codeLines = new List<string>();
            Modifiers = new List<string>();
        }

        
        protected Scope(string value, Scope parent)
        {
            Parent = parent;
            Value = value;
            LanguageSettings = Parent.LanguageSettings;
            IndentLevel = new IndentationManager
            {
                Current = Parent.IndentLevel.Current
            };

            _scopes = new List<Scope>();
            _codeLines = new List<string>();
            Modifiers = new List<string>() { LanguageSettings.Syntax.PublicKeyword };
        }

        internal virtual List<string> GenerateCode()
        {
            _codeLines.Clear();

            foreach (var childScope in _scopes)
            {
                _codeLines.AddRange(childScope.GenerateCode());
            }

            return _codeLines;
        }

        private List<string> ExpandCodeLines(List<string> list)
        {
            var result = new List<string>();


            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var line in list)
            {
                var sublines = line.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

                result.AddRange(sublines);
            }

            return result;
        }

        protected void AddNestedScope(Scope scope)
        {
            _scopes.Add(scope);
        }

        public virtual void ToFile(string filename)
        {
            var text = ToString();

#pragma warning disable RS1035
            if(File.Exists(filename)) File.Delete(filename);
#pragma warning restore RS1035

            using (var writer = new StreamWriter(filename))
            {
                writer.Write(text);
            }
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
            IndentLevel.Decrease();
            _codeLines.AddRange(LanguageSettings.StyledSyntax.GetCloseScope(IndentLevel.Current));
        }

        protected virtual void Dispose(bool disposing)
        {
            Dispose();
        }

        protected void ValidateScope(string name, Type childScopeType)
        {
            if (!(LanguageSettings.Syntax.IsValidNaming(name) &&
                LanguageSettings.Features.ScopeContainmentRules.ContainsKey(this.GetType()) &&
                LanguageSettings.Features.ScopeContainmentRules[this.GetType()].Contains(childScopeType)))
            {
                throw new InvalidOperationException($"Creating a {childScopeType.Name} scope named '{name}' inside a {this.GetType().Name} scope is not allowed in {LanguageSettings.LanguageName}.");
            }
        }

        protected string GetOperatorSpacing()
        {
            return LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
        }

        public virtual RegionScope AddRegion(string name)
        {
            ValidateScope(name, typeof(RegionScope));
            var newScope = new RegionScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual UsingScope AddUsingStatement(string name)
        {
            ValidateScope(name, typeof(UsingScope));
            var newScope = new UsingScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual NamespaceScope AddNamespace(string name)
        {
            ValidateScope(name, typeof(NamespaceScope));
            var newScope = new NamespaceScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual CommentScope AddComment(string name)
        {
            ValidateScope(name, typeof(CommentScope));
            var newScope = new CommentScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual EnumScope AddEnum(string name)
        {
            ValidateScope(name, typeof(EnumScope));
            var newScope = new EnumScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual StructScope AddStruct(string name)
        {
            ValidateScope(name, typeof(StructScope));
            var newScope = new StructScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual InterfaceScope AddInterface(string name)
        {
            ValidateScope(name, typeof(InterfaceScope));
            var newScope = new InterfaceScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual ClassScope AddClass(string name)
        {
            ValidateScope(name, typeof(ClassScope));
            var newScope = new ClassScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertyScope AddProperty(string name)
        {
            ValidateScope(name, typeof(PropertyScope));
            var newScope = new PropertyScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertyGetterScope AddPropertyGetter(string name)
        {
            ValidateScope(name, typeof(PropertyGetterScope));
            var newScope = new PropertyGetterScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual PropertySetterScope AddPropertySetter(string name)
        {
            ValidateScope(name, typeof(PropertySetterScope));
            var newScope = new PropertySetterScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual DelegateScope AddDelegate(string name)
        {
            ValidateScope(name, typeof(DelegateScope));
            var newScope = new DelegateScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual FieldScope AddField(string name)
        {
            ValidateScope(name, typeof(FieldScope));
            var newScope = new FieldScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual MethodScope AddMethod(string name)
        {
            ValidateScope(name, typeof(MethodScope));
            var newScope = new MethodScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }
        public virtual CodeBlockScope AddCodeBlock(string name)
        {
            ValidateScope(name, typeof(CodeBlockScope));
            var newScope = new CodeBlockScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }

        public virtual VariableScope AddVariable(string name)
        {
            ValidateScope(name, typeof(VariableScope));
            var newScope = new VariableScope(name, this);
            AddNestedScope(newScope);

            return newScope;
        }

        protected virtual string GetStyledValue()
        {
            var result = Value;

            if (!LanguageSettings.Style.AutomaticCaseConversion) return result;

            if (this is ClassScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.ClassCaseConversionStyle);
            if (this is DelegateScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.DelegateCaseConversionStyle);
            if (this is EnumScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.EnumCaseConversionStyle);
            if (this is FieldScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.FieldCaseConversionStyle);
            if (this is InterfaceScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.InterfaceCaseConversionStyle);
            if (this is MethodScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.MethodCaseConversionStyle);
            if (this is NamespaceScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.NamespaceCaseConversionStyle);
            if (this is PropertyScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.PropertyCaseConversionStyle);
            if (this is RegionScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.RegionCaseConversionStyle);
            if (this is StructScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.StructCaseConversionStyle);
            if (this is VariableScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.VariableCaseConversionStyle);

            return result;
        }

        protected void ValidateModifiers(IEnumerable<string> modifiers)
        {
            ValidateTypeModifiers(modifiers);
            ValidateModifierCombinations(modifiers);
        }

        private void ValidateTypeModifiers(IEnumerable<string> modifiers)
        {
            var scopeType = this.GetType();

            if (!LanguageSettings.Features.AllowedModifiers.ContainsKey(scopeType)) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifiers for type '{scopeType.Name}' are not allowd.");

            var validModifiers = LanguageSettings.Features.AllowedModifiers[scopeType].Select(m => m.ToLower());

            var invalidModifier = modifiers.FirstOrDefault(m => !validModifiers.Contains(m.ToLower()));
                if(invalidModifier != null) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifier '{invalidModifier}' is not valid for type '{scopeType.Name}'.");
        }

        private void ValidateModifierCombinations(IEnumerable<string> modifiers)
        {
            foreach (var modifier in modifiers)
            {
                if (!LanguageSettings.Features.DisallowedModifierCombinations.ContainsKey(modifier)) continue;

                foreach (var disallowed in LanguageSettings.Features.DisallowedModifierCombinations[modifier])
                {
                    if (modifier.Contains(disallowed)) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifier '{modifier}' cannot be combined with modifier '{disallowed}'.");
                }
            }
        }

        public virtual Scope Up()
        {
            return Parent;
        }

        protected void AddModifier(string modifier)
        {
            if (LanguageSettings.Features.DisallowedModifierCombinations.TryGetValue(modifier, out var combination))
            {
                Modifiers.RemoveAll(m => combination.Select(d => d.ToLower()).Contains(m.ToLower()));
            }

            if (!Modifiers.Contains(modifier)) Modifiers.Add(modifier);
        }
    }
}