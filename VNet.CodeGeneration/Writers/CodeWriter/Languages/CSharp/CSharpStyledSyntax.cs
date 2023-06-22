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



        public string GetSingleIndentCode()
        {
            return GetIndentCode(1);
        }

        public string GetIndentCode(int numberOfIndents)
        {
            var indent = Style.UseSpacesForIndentation ? new string(' ', Style.IndentationWidth) : "\t";

            var singleCode = new string(indent[0], Style.IndentationWidth);

            return string.Concat(Enumerable.Repeat(singleCode, numberOfIndents));
        }

        public IEnumerable<string> GetOpenScope(int currentIndentLevel)
        {
            var result = new List<string>
            {
                Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + Syntax.OpenScopeCharacter
                    : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.OpenScopeCharacter
            };

            return result;
        }

        public IEnumerable<string> GetCloseScope(int currentIndentLevel)
        {
            var result = new List<string>
            {
                Style.BraceStyle == BraceStyle.EndOfLine
                    ? " " + Syntax.CloseScopeCharacter
                    : Style.LineBreakCharacter + GetIndentCode(currentIndentLevel) + Syntax.CloseScopeCharacter
            };

            return result;
        }

        public IEnumerable<string> GetRegionOpenScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
            {
                $"{GetIndentCode(currentIndentLevel)}{Syntax.RegionOpenScopeCharacter} {styledValue}"
            };

            return result;
        }

        public IEnumerable<string> GetRegionCloseScope(string styledValue, int currentIndentLevel)
        {
            var result = new List<string>()
            {
                $"{GetIndentCode(currentIndentLevel)}{Syntax.RegionCloseScopeCharacter} {styledValue}"
            };

            return result;
        }
    
        private string GetModifiers(IEnumerable<string> modifiers)
        {
            return !modifiers.Any() ? string.Empty : string.Join(" ", modifiers).Trim();
        }

        private string GetGenericTypes(IEnumerable<string> genericTypes)
        {
            return !genericTypes.Any() ? string.Empty : $"{Syntax.GenericStart}{GetParameters(genericTypes)}{Syntax.GenericEnd}";
        }

        private string GetGenericConstraints(IEnumerable<string> constraints)
        {
            if (!constraints.Any()) return string.Empty;

            var styled = constraints.Select(c => $" where {c}");
            var joinString = Style.GenericConstraintsOnSingleLine ? " " : Style.LineBreakCharacter;

            return string.Join(joinString, styled);
        }

        private string GetParameters(IEnumerable<string> parameters)
        {
            return string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)} ", parameters).Trim();
        }

        private string GetCombinedDerived(IList<string> derivedClasses, IEnumerable<string> interfaces)
        {
            if(!derivedClasses.Any() && !interfaces.Any()) return string.Empty;

            var baseClass = derivedClasses.Any() ? new List<string>() { derivedClasses[0] } : new List<string>();
            var combined = baseClass.Concat(interfaces);
            var separator = Style.SpaceAroundOperators ? " " : string.Empty;

            return $"{separator}:{separator}{string.Join($",{(Style.SpaceAfterComma ? " " : string.Empty)}", combined)}";

        }

        public IEnumerable<string> GetNamespaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, NamespaceStyle namespaceStyle)
        {
            var codeLines = new List<string>();

            switch (namespaceStyle)
            {
                case NamespaceStyle.Scoped:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.NamespaceKeyword} {styledValue}");
                        break;
                    }
                case NamespaceStyle.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.NamespaceKeyword} {styledValue}{Syntax.StatementEnd}");
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        public IEnumerable<string> GetCommentStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, CommentType commentType)
        {
            var codeLines = new List<string>();
            var values = styledValue.Split(CodeWriter.NewLineDelimiters, StringSplitOptions.None);

            switch (commentType)
            {
                case CommentType.SingleLine:
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.SingleLineCommentCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{styledValue}");
                        break;
                    }
                case CommentType.MultiLine:
                    {
                        if (Style.MultilineCommentStyle == MultilineCommentStyle.SameLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{Syntax.MultilineCommentCloseScopeCharacter}");
                        }

                        if (Style.MultilineCommentStyle == MultilineCommentStyle.NewLine)
                        {
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentOpenScopeCharacter}{values[0]}");
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[0]}");
                            for (var i = 1; i <= values.Length - 3; i++)
                            {
                                codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[i]}");
                            }

                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{values[values.Length - 1]}");
                            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.MultilineCommentCloseScopeCharacter}");
                        }
                    }
                    break;
                case CommentType.Documentation:
                    codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentOpenScopeCharacter}{values[0]}");
                    // ReSharper disable once LoopCanBeConvertedToQuery
                    foreach (var t in values)
                    {
                        codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentCharacter}{(Style.SpaceAfterCommentCharacter ? " " : string.Empty)}{t}");
                    }

                    // TODO: doesn't support documentation for parameters
                    codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.DocumentationCommentCloseScopeCharacter}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return codeLines;
        }

        public IEnumerable<string> GetUsingStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>
            {
                $"{GetIndentCode(indentLevel.Current)}{Syntax.UsingKeyword} {styledValue}{Syntax.StatementEnd}"
            };

            return codeLines;
        }

        public IEnumerable<string> GetEnumStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel, IEnumerable<EnumMember> members)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.EnumKeyword} {styledValue}{GetOpenScope(indentLevel.Current)}");
            
            indentLevel.Increase();
            foreach (var member in members)
            {
                var memberValue = string.Empty;
                if (member.Value.HasValue)
                {
                    memberValue += Style.SpaceAroundOperators ? " " : string.Empty;
                    memberValue += Syntax.EnumValueSeparatorCharacter;
                    memberValue += Style.SpaceAroundOperators ? " " : string.Empty;
                    memberValue += member.Value.ToString();
                }

                codeLines.Add($"{member.Name}{memberValue}{Syntax.EnumMemberSeparatorCharacter}");
            }
            indentLevel.Decrease();


            return codeLines;
        }

        public IEnumerable<string> GetStructStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.StructKeyword} {styledValue}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetInterfaceStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.InterfaceKeyword} {styledValue}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetClassStyledSyntax(string styledValue, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IList<string> derivedFrom, IEnumerable<string> implements, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {Syntax.ClassKeyword} {styledValue}{GetGenericTypes(genericTypes)}{GetCombinedDerived(derivedFrom, implements)}{GetGenericConstraints(genericConstraints)}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetDelegateStyledSyntax(string styledValue, string returnType, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.DelegateKeyword} {styledValue}({GetParameters(parameters)}){Syntax.StatementEnd}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetEventStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.EventKeyword} {styledValue}{Syntax.StatementEnd}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetMethodStyledSyntax(string styledValue, string returnType, IEnumerable<string> genericTypes, IEnumerable<string> genericConstraints, IEnumerable<string> parameters, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {Syntax.MethodKeyword} {styledValue}{GetGenericTypes(genericTypes)}({GetParameters(parameters)}){GetGenericConstraints(genericConstraints)}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetFieldStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {returnType} {styledValue}{Syntax.StatementEnd}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetVariableStyledSyntax(string styledValue, string returnType, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{returnType} {styledValue}{Syntax.StatementEnd}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetPropertyStyledSyntax(string styledValue, string type, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{GetModifiers(modifiers)} {type} {Syntax.PropertyKeyword} {CodeWriter.ConvertStyleCase(styledValue, Style.PropertyCaseConversionStyle)}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetPropertyGetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.PropertyGetterKeyword}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }

        public IEnumerable<string> GetPropertySetterStyledSyntax(string styledValue, IEnumerable<string> modifiers, IndentationManager indentLevel)
        {
            var codeLines = new List<string>();

            codeLines.Add($"{GetIndentCode(indentLevel.Current)}{Syntax.PropertySetterKeyword}{GetOpenScope(indentLevel.Current)}");
            indentLevel.Increase();

            return codeLines;
        }
    }
}