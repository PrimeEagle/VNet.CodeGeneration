using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Log;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedMember.Local
#pragma warning disable IDE0051

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class Scope
    {
        public IProgrammingLanguageSettings LanguageSettings { get; protected set; }
        public string Value { get; private set; }
        public string StyledValue
        {
            get
            {
                var result = Value;

                if (!LanguageSettings.Style.AutomaticCaseConversion) return result;
                result = CodeWriter.ConvertStyleCase(result, CaseConversionStyle);

                return result;
            }
        }
        protected List<Scope> Scopes;
        public Scope Parent { get; private set; }
        protected IndentationManager IndentLevel { get; set; }
        protected List<string> CodeLines { get; private set; }
        protected List<string> Modifiers;
        protected List<object> Parameters { get; set; }
        protected abstract CaseConversionStyle CaseConversionStyle { get; }


        protected Scope()
        {
            IndentLevel = new IndentationManager();
            CodeLines = new List<string>();
            Modifiers = new List<string>();
            Scopes = new List<Scope>();
            Parameters = new List<object>();
        }

        protected Scope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
        {
            Parent = parent;
            Value = value;
            LanguageSettings = Parent.LanguageSettings;
            IndentLevel = indentLevel;
            CodeLines = codeLines;
            Scopes = new List<Scope>();
            Modifiers = new List<string>();
            Parameters = parameters ?? new List<object>();
        }

        internal abstract void GenerateCode();
        protected abstract void WriteCodeLines(CodeResult result);

        protected void ProcessCodeResult(CodeResult result, bool indentedBlock = false)
        {
            if (result == null) return;

            var indentStr = GetIndent(IndentLevel.Current);

            for (var i = 0; i < result.OpenScopeLines.Count; i++)
            {
                CodeLines.Add($"{indentStr}{result.OpenScopeLines[i]}");
            }

            if (indentedBlock)
            {
                IndentLevel.Increase();
                indentStr = GetIndent(IndentLevel.Current);
            }

            for (var i = 0; i < result.ScopeCodeLines.Count; i++)
            {
                CodeLines.Add($"{indentStr}{result.ScopeCodeLines[i]}");
            }

            for (var i = 0; i < result.UnscopedCodeLines.Count; i++)
            {
                CodeLines.Add($"{indentStr}{result.UnscopedCodeLines[i]}");
            }

            for (var s = 0; s < Scopes.Count; s++)
                Scopes[s].GenerateCode();

            CodeWriter.AppentToLastElement(CodeLines, $"{CodeLines[CodeLines.Count - 1]}{result.PreviousCodeLineSuffix ?? string.Empty}");

            if (indentedBlock)
            {
                IndentLevel.Decrease();
                indentStr = GetIndent(IndentLevel.Current);
            }

            for (var i = 0; i < result.CloseScopeLines.Count; i++)
            {
                CodeLines.Add($"{indentStr}{result.CloseScopeLines[i]}");
            }
        }

        //protected List<string> ExpandCodeLines(List<string> list)
        //{
        //    var result = new List<string>();

        //    foreach (var line in list)
        //    {
        //        var sublines = line.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

        //        result.AddRange(sublines);
        //    }

        //    return result;
        //}

        protected void AddNestedScope(Scope scope)
        {
            Scopes.Add(scope);
        }

        public virtual void ToFile(string filename)
        {
            var text = ToString();

            var log = new Logger();
            log.Initialize(@"D:\generator.log");
            log.WriteLine(text);
            //if (File.Exists(filename)) File.Delete(filename);

            //using (var writer = new StreamWriter(filename))
            //{
            //    writer.Write(text);
            //}
        }

        public override string ToString()
        {
            CodeLines.Clear();
            GenerateCode();

            return string.Join(LanguageSettings.Style.LineBreakSymbol, CodeLines.Select(SplitLine));
        }

        private List<string> SplitLine(string line)
        {
            var result = new List<string>() { line };

            if (!LanguageSettings.Style.BreakLongLines) return result;
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
                if (char.IsWhiteSpace(line[i]))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        protected void ValidateScope(string name, Type childScopeType, bool skipNameValidation = false)
        {
            if (!skipNameValidation && !LanguageSettings.Syntax.IsValidNaming(name))
            {
                throw new InvalidOperationException($"A {childScopeType.Name} scope named '{name}' is not valid in {LanguageSettings.Name}.");
            }

            //if (!LanguageSettings.Features.ScopeContainmentRules.ContainsKey(this.GetType()))
            //{
            //    throw new InvalidOperationException($"Scope of type {this.GetType().Name} is not valid in {LanguageSettings.LanguageName}.");
            //}

            //if (!LanguageSettings.Features.ScopeContainmentRules[this.GetType()].Contains(childScopeType))
            //{
            //    throw new InvalidOperationException($"Creating a {childScopeType.Name} scope inside a {this.GetType().Name} scope is not allowed in {LanguageSettings.LanguageName}.");
            //}
        }

        //protected string GetOperatorSpacing()
        //{
        //    return LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
        //}



        //protected virtual string GetStyledValue()
        //{
        //    var result = Value;

        //    if (!LanguageSettings.Style.AutomaticCaseConversion) return result;

        //    if (this is ClassScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.ClassCaseConversionStyle);
        //    if (this is DelegateScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.DelegateCaseConversionStyle);
        //    if (this is EnumerationScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.EnumerationCaseConversionStyle);
        //    if (this is FieldScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.FieldCaseConversionStyle);
        //    if (this is InterfaceScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.InterfaceCaseConversionStyle);
        //    if (this is FunctionScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.FunctionCaseConversionStyle);
        //    if (this is ModuleScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.ModuleCaseConversionStyle);
        //    if (this is AccessorScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.AccessorCaseConversionStyle);
        //    if (this is CodeGroupingScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.CodeGroupingCaseConversionStyle);
        //    if (this is StructScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.StructCaseConversionStyle);
        //    if (this is VariableScope) result = CodeWriter.ConvertStyleCase(result, LanguageSettings.Style.VariableCaseConversionStyle);

        //    return result;
        //}

        //protected void ValidateModifiers(IEnumerable<string> modifiers)
        //{
        //    ValidateTypeModifiers(modifiers);
        //    ValidateModifierCombinations(modifiers);
        //}

        //private void ValidateTypeModifiers(IEnumerable<string> modifiers)
        //{
        //    var scopeType = this.GetType();

        //    if (!LanguageSettings.Features.AllowedModifiers.ContainsKey(scopeType)) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifiers for type '{scopeType.Name}' are not allowed.");

        //    var validModifiers = LanguageSettings.Features.AllowedModifiers[scopeType].Select(m => m.ToLower());

        //    var invalidModifier = modifiers.FirstOrDefault(m => !validModifiers.Contains(m.ToLower()));
        //    if (invalidModifier != null) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifier '{invalidModifier}' is not valid for type '{scopeType.Name}'.");
        //}

        //private void ValidateModifierCombinations(IEnumerable<string> modifiers)
        //{
        //    foreach (var modifier in modifiers)
        //    {
        //        if (!LanguageSettings.Features.DisallowedModifierCombinations.ContainsKey(modifier)) continue;

        //        foreach (var disallowed in LanguageSettings.Features.DisallowedModifierCombinations[modifier])
        //        {
        //            if (modifier.Contains(disallowed)) throw new ArgumentException($"In {LanguageSettings.LanguageName}, modifier '{modifier}' cannot be combined with modifier '{disallowed}'.");
        //        }
        //    }
        //}

        //public virtual Scope Up()
        //{
        //    return Parent;
        //}

        //protected void AddModifier(string modifier)
        //{
        //    if (LanguageSettings.Features.DisallowedModifierCombinations.TryGetValue(modifier, out var combination))
        //    {
        //        Modifiers.RemoveAll(m => combination.Select(d => d.ToLower()).Contains(m.ToLower()));
        //    }

        //    if (!Modifiers.Contains(modifier)) Modifiers.Add(modifier);
        //}

        protected string GetSingleIndent()
        {
            return GetIndent(1);
        }

        protected string GetIndent(int numberOfIndents)
        {
            var indentChar = LanguageSettings.Style.UseSpacesForIndentation ? new string(' ', LanguageSettings.Style.IndentationWidth)[0] : '\t';
            var singleCode = new string(indentChar, LanguageSettings.Style.IndentationWidth);

            return string.Concat(Enumerable.Repeat(singleCode, numberOfIndents));
        }

        protected void GetOpenScope(CodeResult result)
        {
            if (LanguageSettings.Style.ScopeOpenStyle == LineStyle.SameLine)
            {
                CodeWriter.AppentToLastElement(result.OpenScopeLines,
                    $"{(LanguageSettings.Style.SpaceBeforeSameLineScope ? " " : string.Empty)}{LanguageSettings.Syntax.OpenScopeSymbol}");
            }
            else if (LanguageSettings.Style.ScopeOpenStyle == LineStyle.NewLine)
            {
                result.OpenScopeLines.Add($"{LanguageSettings.Syntax.OpenScopeSymbol}");
            }
        }

        protected CodeResult GetCloseScope(CodeResult cr)
        {
            var result = new CodeResult();

            if (LanguageSettings.Style.ScopeCloseStyle == LineStyle.SameLine)
            {
                result.PreviousCodeLineSuffix = $"{(LanguageSettings.Style.SpaceBeforeSameLineScope ? " " : string.Empty)}{LanguageSettings.Syntax.CloseScopeSymbol}";
            }
            else if (LanguageSettings.Style.ScopeCloseStyle == LineStyle.NewLine)
            {
                result.CloseScopeLines.Add($"{LanguageSettings.Syntax.CloseScopeSymbol}");
            }

            return result;
        }

        public Scope Up()
        {
            return this.Parent;
        }

        public T Up<T>() where T : Scope
        {
            return (T)this.Parent;
        }
    }
}