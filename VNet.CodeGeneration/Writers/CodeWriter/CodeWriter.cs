using System;
using System.Collections.Generic;

// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    internal static class CodeWriter
    {
        internal static string[] NewLineDelimiters => new string[]{ "\r\n", "\r", "\n" };

        internal static string ConvertStyleCase(string name, CaseConversionStyle conversionStyle)
        {
            string result;

            switch (conversionStyle)
            {
                case CaseConversionStyle.None:
                    result = name;
                    break;
                case CaseConversionStyle.Lower:
                    result = ConvertCase.ToAlLLower(name);
                    break;
                case CaseConversionStyle.Upper:
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

        internal static void AppendToLastElement(this List<string> source, string text)
        {
            if(source == null || source.Count == 0) return;

            source[source.Count - 1] = $"{source[source.Count - 1]}{text}";
        }

        internal static void InsertRange<T>(this List<T> source, int index, List<T> list)
        {
            if (index > source.Count) throw new ArgumentOutOfRangeException(nameof(index));

            for(var i = list.Count - 1; i >= 0; i--) 
            {
                source.Insert(index, list[i]);
            }
        }
    }
}