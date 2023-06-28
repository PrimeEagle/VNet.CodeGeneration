using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable UnusedParameter.Global
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedMember.Local
#pragma warning disable IDE0028


namespace VNet.CodeGeneration.Writers.CodeWriter.Languages.CSharp
{
    public class CSharpStyledSyntax : IProgrammingLanguageStyledSyntax
    {
        public IProgrammingLanguageSyntax Syntax { get; }
        public IProgrammingLanguageStyle Style { get; }

        public CSharpStyledSyntax(IProgrammingLanguageSyntax syntax, IProgrammingLanguageStyle style)
        {
            Syntax = syntax;
            Style = style;
        }

        //public string GetSingleIndentCode()
        //{
        //    return GetIndent(1);
        //}

        //public string GetIndent(int numberOfIndents)
        //{
        //    var indentChar = Style.UseSpacesForIndentation ? new string(' ', Style.IndentationWidth)[0] : '\t';
        //    var singleCode = new string(indentChar, Style.IndentationWidth);

        //    return string.Concat(Enumerable.Repeat(singleCode, numberOfIndents));
        //}

        //public CodeResult GetOpenScope(int currentIndentLevel)
        //{
        //    var result = new CodeResult();

        //    if(Style.ScopeDelimiterStyle == ScopeDelimiterStyle.SameLine)
        //    {
        //        result.PreviousLineSuffix = $" { Syntax.OpenScopeSymbol}";
        //    }
        //    else if(Style.ScopeDelimiterStyle == ScopeDelimiterStyle.NewLine)
        //    {
        //        result.PostOpenScopeNewLines.Add(GetIndent(currentIndentLevel) + Syntax.OpenScopeSymbol);
        //    }

        //    return result;
        //}

        //public CodeResult GetCloseScope(int currentIndentLevel)
        //{
        //    var result = new CodeResult();

        //    if (Style.ScopeDelimiterStyle == ScopeDelimiterStyle.SameLine)
        //    {
        //        result.PreviousLineSuffix = $" {Syntax.OpenScopeSymbol}";
        //    }
        //    else if (Style.ScopeDelimiterStyle == ScopeDelimiterStyle.NewLine)
        //    {
        //        result.PostOpenScopeNewLines.Add(GetIndent(currentIndentLevel) + Syntax.OpenScopeSymbol);
        //    }

        //    return result;
        //}

        public IEnumerable<string> GetCodeGroupingOpenScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
            {
                $"{GetIndent(currentIndentLevel)}{Syntax.CodeGroupingOpenSymbol} {styledValue}"
            };

            return result;
        }

        public IEnumerable<string> GetCodeGroupingCloseScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
            {
                $"{GetIndent(currentIndentLevel)}{Syntax.CodeGroupingCloseSymbol} {styledValue}"
            };

            return result;
        }
    
        //private string GetModifiers(IEnumerable<string> modifiers)
        //{
        //    return !modifiers.Any() ? string.Empty : string.Join(" ", modifiers).Trim();
        //}

        //private string GetGenericTypes(IEnumerable<string> genericTypes)
        //{
        //    return !genericTypes.Any() ? string.Empty : $"{Syntax.GenericScopeOpenSymbol}{GetParameters(genericTypes)}{Syntax.GenericScopeCloseSymbol}";
        //}

        //private string GetGenericConstraints(IEnumerable<string> constraints)
        //{
        //    if (!constraints.Any()) return string.Empty;

        //    var styled = constraints.Select(c => $" where {c}");
        //    var joinString = Style.GenericConstraintsOnSingleLine ? " " : Style.LineBreakSymbol;

        //    return string.Join(joinString, styled);
        //}

        //private string GetParameters(IEnumerable<string> parameters)
        //{
        //    return string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)} ", parameters).Trim();
        //}

        //private string GetCombinedDerived(IList<string> derivedClasses, IEnumerable<string> interfaces)
        //{
        //    if(!derivedClasses.Any() && !interfaces.Any()) return string.Empty;

        //    var baseClass = derivedClasses.Any() ? new List<string>() { derivedClasses[0] } : new List<string>();
        //    var combined = baseClass.Concat(interfaces);
        //    var separator = Style.SpaceAroundOperators ? " " : string.Empty;

        //    return $"{separator}{Syntax.ClassDerivationSymbol}{separator}{string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)}", combined)}";

        //}

        public IEnumerable<string> GetModuleStyledSyntax(string styledValue, ModuleStyle moduleStyle, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            switch (moduleStyle)
            {
                case ModuleStyle.Scoped:
                    {
                        codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.ModuleKeyword} {styledValue}");
                        break;
                    }
                case ModuleStyle.SingleLine:
                    {
                        codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.ModuleKeyword} {styledValue}{Syntax.StatementEndSymbol}");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, CommentType commentType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();
            var values = styledValue.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

            switch (commentType)
            {
                case CommentType.SingleLine:
                    {
                        codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.SingleLineCommentSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{styledValue}");
                        break;
                    }
                case CommentType.MultiLine:
                    {
                        if (Style.MultilineCommentStyle == MultilineCommentStyle.SameLine)
                        {
                            codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndent(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndent(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.MultilineCommentCloseScopeSymbol}");
                        }

                        if (Style.MultilineCommentStyle == MultilineCommentStyle.NewLine)
                        {
                            codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeSymbol}{values[0]}");
                            codeLines.Add($"{GetIndent(indentLevel.Current)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndent(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndent(indentLevel.Current)}{values[values.Length - 1]}");
                            codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.MultilineCommentCloseScopeSymbol}");
                        }
                    }
                    break;
                case CommentType.Documentation:
                    codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.DocumentationCommentOpenScopeSymbol}{values[0]}");
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (var t in values)
                    {
                        codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.DocumentationCommentOpenScopeSymbol}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{t}");
                    }

                    // TODO: doesn't support documentation for parameters
                    codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.DocumentationCommentCloseScopeSymbol}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        //public IEnumerable<string> GetImportStyledSyntax(string styledValue, ImportType importType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    var codeLines = new List<string>
        //    {
        //        $"{GetIndent(indentLevel.Current)}{Syntax.ImportKeyword} {styledValue}{Syntax.StatementEndSymbol}"
        //    };

        //    return codeLines;
        //}

        public IEnumerable<string> GetEnumerationStyledSyntax(string styledValue, IEnumerable<EnumerationMember> members, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.EnumerationKeyword} {styledValue}{GetOpenScope(indentLevel.Current)[0]}");
            
            indentLevel.Increase();
            foreach (var member in members)
            {
                var memberValue = string.Empty;
                if (member.Value.HasValue)
                {
                    memberValue += Style.SpaceAroundOperators ? " " : string.Empty;
                    memberValue += Syntax.EnumerationValueSeparatorSymbol;
                    memberValue += Style.SpaceAroundOperators ? " " : string.Empty;
                    memberValue += member.Value.ToString();
                }

                codeLines.Add($"{member.Name}{memberValue}{Syntax.EnumerationMemberSeparatorSymbol}");
            }
            indentLevel.Decrease();


            return codeLines;
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.StructKeyword} {styledValue}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.InterfaceKeyword} {styledValue}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.ClassKeyword} {styledValue}{GetGenericTypes(genericTypes)}{GetCombinedDerived(derivedFrom, implements)}{GetGenericConstraints(genericConstraints)}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.DelegateKeyword} {styledValue}({GetParameters(parameters)}){Syntax.StatementEndSymbol}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.EventKeyword} {styledValue}{Syntax.StatementEndSymbol}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetFunctionStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> parameters, IList<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.FunctionKeyword} {styledValue}{GetGenericTypes(genericTypes)}({GetParameters(parameters)}){GetGenericConstraints(genericConstraints)}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        //public IEnumerable<string> GetFieldStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    var codeLines = new List<string>();

        //    codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {styledValue}{Syntax.StatementEndSymbol}");
        //    indentLevel.Increase();

        //    return codeLines;
        //}

        //public IEnumerable<string> GetVariableStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    var codeLines = new List<string>();

        //    codeLines.Add($"{GetIndent(indentLevel.Current)}{returnType} {styledValue}{Syntax.StatementEndSymbol}");
        //    indentLevel.Increase();

        //    return codeLines;
        //}

        public IEnumerable<string> GetAccessorStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{GetModifiers(modifiers)} {type} {Syntax.AccessorKeyword} {CodeWriter.ConvertStyleCase(styledValue, Style.AccessorCaseConversionStyle)}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.GetterKeyword}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetSetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndent(indentLevel.Current)}{Syntax.SetterKeyword}{GetOpenScope(indentLevel.Current)[0]}");
            indentLevel.Increase();

            return codeLines;
        }

        //public IEnumerable<string> GetCodeGroupingPostScope(string styledValue, int currentIndentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetModulePostScopeStyledSyntax(string styledValue, ModuleStyle moduleStyle, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetCommentPostScopeStyledSyntax(string styledValue, CommentType commentType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetImportPostScopeStyledSyntax(string styledValue, ImportType importType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetEnumerationPostScopeStyledSyntax(string styledValue, IEnumerable<EnumerationMember> members, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetStructPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetInterfacePostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetClassPostScopeStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetDelegatePostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetEventPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetFunctionPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> parameters, IList<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetFieldPostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetVariablePostScopeStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetAccessorPostScopeStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetGetterPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}

        //public IEnumerable<string> GetSetterPostScopeStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        //{
        //    return new List<string>();
        //}
    }
}