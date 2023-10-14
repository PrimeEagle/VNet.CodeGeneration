using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable MemberCanBePrivate.Global


namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public abstract class Scope
    {
        public IStructuredLanguageSettings LanguageSettings { get; protected set; }
        public string Value { get; protected set; }
        public string StyledValue
        {
            get
            {
                var result = Value;

                if (!LanguageSettings.Style.AutomaticCaseConversion) return result;
                result = ConvertCase.ConvertStyleCase(result, CaseConversionStyle);

                return result;
            }
        }
        protected readonly List<Scope> Scopes;
        public Scope Parent { get; private set; }
        protected IndentationManager IndentLevel { get; set; }
        protected List<string> CodeLines { get; private set; }
        protected List<object> Parameters { get; set; }
        protected abstract CaseConversionStyle CaseConversionStyle { get; }
        protected virtual string AlternateOpenScopeOpenSymbol { get; }
        protected virtual string AlternateOpenScopeCloseSymbol { get; }
        protected virtual string AlternateCloseScopeOpenSymbol { get; }
        protected virtual string AlternateCloseScopeCloseSymbol { get; }


        #region Style Helpers
        protected string SpOp => LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
        protected string SpComma => LanguageSettings.Style.SpaceAfterComma ? " " : string.Empty;
        protected string SpComment => LanguageSettings.Style.SpaceAfterCommentCharacter ? " " : string.Empty;
        protected string Qu => LanguageSettings.Style.QuoteSymbol;

        #endregion Style Helpers


        protected Scope(string value, List<object> parameters, IStructuredLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
        {
            Parent = parent;
            Value = value;
            LanguageSettings = languageSettings;
            IndentLevel = indentLevel;
            CodeLines = codeLines;
            Scopes = new List<Scope>();
            Parameters = parameters ?? new List<object>();
            AlternateOpenScopeOpenSymbol = null;
            AlternateOpenScopeCloseSymbol = null;
            AlternateCloseScopeOpenSymbol = null;
            AlternateCloseScopeCloseSymbol = null;
        }

        internal abstract void GenerateCode();
        protected abstract void WriteCode(CodeResult result);

        protected void ProcessCodeResult(CodeResult result, bool scoped)
        {
            if (result == null) return;

            var indentStr = GetIndent(IndentLevel.Current);

            // Scope opening
            if (scoped)
            {
                var os = new CodeResult();
                GetOpenScopeOpen(os);
                GetOpenScopeClose(os);

                var linePre = $"{indentStr}{os.PreOpenScope}";
                linePre = result.InsideOpenScope.Aggregate(linePre, (current, t) => current + t);
                linePre += os.PostOpenScope;
                CodeLines.Add(linePre);

                IndentLevel.Increase();
                indentStr = GetIndent(IndentLevel.Current);

                // Scoped
                foreach (var t in result.ScopedCodeLines)
                {
                    CodeLines.Add($"{indentStr}{t}");
                }
            }

            // Unscoped
            foreach (var t in result.UnscopedCodeLines)
            {
                CodeLines.Add($"{indentStr}{t}");
            }

            foreach (var t in Scopes)
            {
                t.GenerateCode();
                CodeLines.AppendToLastElement(LanguageSettings.Syntax.ScopeListSeparatorSymbol);
            }

            // Scope closing
            if (!scoped) return;

            var cs = new CodeResult();
            GetOpenScopeOpen(cs);
            GetOpenScopeClose(cs);

            var line = $"{indentStr}{cs.PreCloseScope}";
            line = result.InsideCloseScope.Aggregate(line, (current, t) => current + t);
            line += cs.PostCloseScope;

            IndentLevel.Decrease();
            indentStr = GetIndent(IndentLevel.Current);
        }

        protected void AddNestedScope(Scope scope)
        {
            Scopes.Add(scope);
        }

        public virtual void Save(string fileName, bool append = false)
        {
            var text = ToString();

            if (LanguageSettings.EnforceDefaultFileExtension)
            {
                var newExtension = $"{LanguageSettings.DefaultFileExtensionPrefix}{LanguageSettings.DefaultFileExtension}";
                if (newExtension.StartsWith(".")) newExtension = newExtension.Substring(1);
                if (Path.HasExtension(fileName))
                {
                    fileName = Path.ChangeExtension(fileName, newExtension);
                }
                else
                {
                    fileName += $".{newExtension}";
                }
            }

            if (File.Exists(fileName) && !append) File.Delete(fileName);

            using (var writer = new StreamWriter(fileName, append))
            {
                writer.Write(text);
            }
        }

        public override string ToString()
        {
            CodeLines.Clear();
            GenerateCode();

            return string.Join(LanguageSettings.Style.LineBreakSymbol, CodeLines);
        }

        protected void ValidateScope(string name, Type childScopeType, bool skipNameValidation = false)
        {
            if (!skipNameValidation && !LanguageSettings.Syntax.IsValidNaming(name))
            {
                throw new InvalidOperationException($"A {childScopeType.Name} scope named '{name}' is not valid in {LanguageSettings.Name}.");
            }
        }

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

        protected void GetOpenScopeOpen(CodeResult result)
        {
            var scopeSymbol = AlternateOpenScopeOpenSymbol ?? LanguageSettings.Syntax.OpenScopeOpenSymbol;

            result.PreOpenScope = $"{scopeSymbol}";
        }

        protected void GetOpenScopeClose(CodeResult result)
        {
            var scopeSymbol = AlternateOpenScopeCloseSymbol ?? LanguageSettings.Syntax.OpenScopeCloseSymbol;

            result.PostOpenScope = $"{scopeSymbol}";
        }

        protected void GetCloseScopeOpen(CodeResult result)
        {
            var scopeSymbol = AlternateCloseScopeOpenSymbol ?? LanguageSettings.Syntax.CloseScopeOpenSymbol;

            result.PreCloseScope = $"{scopeSymbol}";
        }

        protected void GetCloseScopeClose(CodeResult result)
        {
            var scopeSymbol = AlternateCloseScopeCloseSymbol ?? LanguageSettings.Syntax.CloseScopeCloseSymbol;

            result.PostCloseScope = $"{scopeSymbol}";
        }
    }
}