using System;

// ReSharper disable NotAccessedField.Local

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class CodeWriter
    {
        public static CodeFile CreateCodeFile()
        {
            return new CodeFile();
        }

        internal static string[] NewLineDelimiters => new string[]{ Environment.NewLine, "\r\n", "\r", "\n" };

        internal static string ConvertStyleCase(string name, CaseConversionStyle conversionStyle)
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
    }
}