using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#pragma warning disable IDE0051

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
        protected List<Scope> Scopes;
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
        protected string spOp => LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
        protected string spComma => LanguageSettings.Style.SpaceAfterComma ? " " : string.Empty;
        protected string spComment => LanguageSettings.Style.SpaceAfterCommentCharacter ? " " : string.Empty;
        protected string qu => LanguageSettings.Style.QuoteSymbol;

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

                var line = $"{indentStr}{os.PreOpenScope}";
                for (var i = 0; i < result.InsideOpenScope.Count; i++)
                {
                    line += result.InsideOpenScope[i];
                }
                line += os.PostOpenScope;
                CodeLines.Add(line);

                IndentLevel.Increase();
                indentStr = GetIndent(IndentLevel.Current);

                // Scoped
                for (var i = 0; i < result.ScopedCodeLines.Count; i++)
                {
                    CodeLines.Add($"{indentStr}{result.ScopedCodeLines[i]}");
                }
            }

            // Unscoped
            for (var i = 0; i < result.UnscopedCodeLines.Count; i++)
            {
                CodeLines.Add($"{indentStr}{result.UnscopedCodeLines[i]}");
            }

            for (var s = 0; s < Scopes.Count; s++)
            {
                Scopes[s].GenerateCode();
                CodeLines.AppendToLastElement(LanguageSettings.Syntax.ScopeListSeparatorSymbol);
            }

            // Scope closing
            if (scoped)
            {
                var cs = new CodeResult();
                GetOpenScopeOpen(cs);
                GetOpenScopeClose(cs);

                var line = $"{indentStr}{cs.PreCloseScope}";
                for (var i = 0; i < result.InsideCloseScope.Count; i++)
                {
                    line += result.InsideCloseScope[i];
                }
                line += cs.PostCloseScope;

                IndentLevel.Decrease();
                indentStr = GetIndent(IndentLevel.Current);
            }
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
                    Path.ChangeExtension(fileName, newExtension);
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
            var scopeSymbol = AlternateOpenScopeOpenSymbol == null ? LanguageSettings.Syntax.OpenScopeOpenSymbol : AlternateOpenScopeOpenSymbol;

            result.PreOpenScope = $"{scopeSymbol}";
        }

        protected void GetOpenScopeClose(CodeResult result)
        {
            var scopeSymbol = AlternateOpenScopeCloseSymbol == null ? LanguageSettings.Syntax.OpenScopeCloseSymbol : AlternateOpenScopeCloseSymbol;

            result.PostOpenScope = $"{scopeSymbol}";
        }

        protected void GetCloseScopeOpen(CodeResult result)
        {
            var scopeSymbol = AlternateCloseScopeOpenSymbol == null ? LanguageSettings.Syntax.CloseScopeOpenSymbol : AlternateCloseScopeOpenSymbol;

            result.PreCloseScope = $"{scopeSymbol}";
        }

        protected void GetCloseScopeClose(CodeResult result)
        {
            var scopeSymbol = AlternateCloseScopeCloseSymbol == null ? LanguageSettings.Syntax.CloseScopeCloseSymbol : AlternateCloseScopeCloseSymbol;

            result.PostCloseScope = $"{scopeSymbol}";
        }
    }
}