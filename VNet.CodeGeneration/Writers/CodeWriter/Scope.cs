using System;
using System.Collections.Generic;
using System.Linq;
using VNet.CodeGeneration.Log;
#pragma warning disable IDE0051

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public abstract class Scope
    {
        public IProgrammingLanguageSettings LanguageSettings { get; protected set; }
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
        protected List<string> Modifiers;
        protected List<object> Parameters { get; set; }
        protected abstract CaseConversionStyle CaseConversionStyle { get; }
        protected virtual string AlternateScopeOpenSymbol { get; }
        protected virtual string AlternateScopeCloseSymbol { get; }


        #region Style Helpers
        protected string spOp => LanguageSettings.Style.SpaceAroundOperators ? " " : string.Empty;
        protected string spComma => LanguageSettings.Style.SpaceAfterComma ? " " : string.Empty;
        protected string spIParen => LanguageSettings.Style.SpaceInsideParentheses ? " " : string.Empty;
        protected string spOParen => LanguageSettings.Style.SpaceOutsideParentheses ? " " : string.Empty;
        protected string spComment => LanguageSettings.Style.SpaceAfterCommentCharacter ? " " : string.Empty;
        protected string spScope => LanguageSettings.Style.SpaceBeforeSameLineScope ? " " : string.Empty;

        #endregion Style Helpers


        protected Scope(string value, List<object> parameters, IProgrammingLanguageSettings languageSettings, Scope parent, IndentationManager indentLevel, List<string> codeLines)
        {
            Parent = parent;
            Value = value;
            LanguageSettings = languageSettings;
            IndentLevel = indentLevel;
            CodeLines = codeLines;
            Scopes = new List<Scope>();
            Modifiers = new List<string>();
            Parameters = parameters ?? new List<object>();
            AlternateScopeOpenSymbol = null;
            AlternateScopeCloseSymbol = null;
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
                for (var i = 0; i < result.PreOpenScopeLines.Count; i++)
                {
                    CodeLines.Add($"{indentStr}{result.PreOpenScopeLines[i]}");
                }

                // open scope
                var os = new CodeResult();
                GetOpenScope(os);
                CodeLines.AppendToLastElement(os.PreviousCodeLineSuffix);
                result.PostOpenScopeLines.InsertRange(0, os.PostOpenScopeLines);

                for (var i = 0; i < result.PostOpenScopeLines.Count; i++)
                {
                    CodeLines.Add($"{indentStr}{result.PostOpenScopeLines[i]}");
                }

                IndentLevel.Increase();
                indentStr = GetIndent(IndentLevel.Current);

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
                Scopes[s].GenerateCode();

            // Scope closing
            if (scoped)
            {
                CodeLines.AppendToLastElement($"{(result.PreviousCodeLineSuffix ?? string.Empty)}");

                IndentLevel.Decrease();
                indentStr = GetIndent(IndentLevel.Current);

                //
                var cs = new CodeResult();
                GetCloseScope(cs);
                CodeLines.AppendToLastElement(cs.PreviousCodeLineSuffix);
                result.PostCloseScopeLines.InsertRange(0, cs.PostCloseScopeLines);

                for (var i = 0; i < result.PostCloseScopeLines.Count; i++)
                {
                    CodeLines.Add($"{indentStr}{result.PostCloseScopeLines[i]}");
                }
            }
        }

        protected void AddNestedScope(Scope scope)
        {
            Scopes.Add(scope);
        }

        public virtual void Save(string fileName)
        {
            var text = ToString();

            var log = new Logger();
            log.Initialize(@"D:\generator.log");
            log.WriteLine(text);
            //if (LanguageSettings.EnforceDefaultFileExtension)
            //{
            //    var newExtension = $"{LanguageSettings.DefaultFileExtensionPrefix}{LanguageSettings.DefaultFileExtension}";
            //    if (newExtension.StartsWith(".")) newExtension = newExtension.Substring(1);

            //    Path.ChangeExtension(fileName, newExtension);
            //}

            //if (File.Exists(fileName)) File.Delete(fileName);

            //using (var writer = new StreamWriter(fileName))
            //{
            //    writer.Write(text);
            //}
        }

        public override string ToString()
        {
            CodeLines.Clear();
            GenerateCode();

            var result = new List<string>();
            for(var i = 0; i < CodeLines.Count; i++)
            {
                var codeLine = CodeLines[i];
                var temp = SplitLine(codeLine);
                result.AddRange(temp);
            }

            return string.Join(LanguageSettings.Style.LineBreakSymbol, result);
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

        protected void GetOpenScope(CodeResult result)
        {
            var scopeSymbol = AlternateScopeOpenSymbol == null ? LanguageSettings.Syntax.OpenScopeSymbol : AlternateScopeOpenSymbol;

            if (LanguageSettings.Style.ScopeOpenStyle == ScopeStyle.SameLine)
            {
                result.PreviousCodeLineSuffix = $"{spScope}{scopeSymbol}";
            }
            else if (LanguageSettings.Style.ScopeOpenStyle == ScopeStyle.NewLine)
            {
                result.PostOpenScopeLines.Add($"{scopeSymbol}");
            }
        }

        protected CodeResult GetCloseScope(CodeResult result)
        {
            var scopeSymbol = AlternateScopeCloseSymbol == null ? LanguageSettings.Syntax.CloseScopeSymbol : AlternateScopeCloseSymbol;

            if (LanguageSettings.Style.ScopeCloseStyle == ScopeStyle.SameLine)
            {
                result.PreviousCodeLineSuffix = $"{spScope}{scopeSymbol}";
            }
            else if (LanguageSettings.Style.ScopeCloseStyle == ScopeStyle.NewLine)
            {
                result.PostCloseScopeLines.Add($"{scopeSymbol}");
            }

            return result;
        }
    }
}