﻿using System;
using System.Linq;
// ReSharper disable FieldCanBeMadeReadOnly.Local
// ReSharper disable InconsistentNaming
#pragma warning disable IDE0044

namespace VNet.CodeGeneration.Writers
{
    public static class ConvertCase
    {
        private static char[] delimiters = new char[] { ' ', '_', '-', '.' };

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

        public static string ToPascal(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = ToTitleCase(words[i]);

            return string.Concat(words);
        }

        public static string ToCamel(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
                if (i == 0)
                    words[i] = words[i].ToLower();
                else
                    words[i] = ToTitleCase(words[i]);

            return string.Concat(words);
        }

        public static string ToTitle(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i].ToLower();

                if (i > 0 && IsLowercaseWord(word))
                    words[i] = word;
                else
                    words[i] = ToTitleCase(word);
            }

            return string.Concat(words);
        }

        private static bool IsLowercaseWord(string word)
        {
            string[] lowercaseWords = { "a", "an", "the", "in", "on", "at", "for", "to", "with", "and", "but", "or", "of" };
            return lowercaseWords.Contains(word.ToLower());
        }

        public static string ToSnake(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = words[i].ToLower();

            return string.Join("_", words);
        }

        public static string ToScreamingSnake(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = words[i].ToUpper();

            return string.Join("_", words);
        }

        public static string ToKebab(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = words[i].ToLower();

            return string.Join("-", words);
        }

        public static string ToScreamingKebab(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = words[i].ToUpper();

            return string.Join("-", words);
        }

        public static string ToAlLLower(string input)
        {
            return input.ToLower();
        }

        public static string ToAllUpper(string input)
        {
            return input.ToUpper();
        }

        public static string ToTitleDot(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = ToTitleCase(words[i]);

            return string.Join(".", words);
        }

        public static string ToLowerDot(string input)
        {
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++) words[i] = words[i].ToLower();

            return string.Join(".", words);
        }

        private static string ToTitleCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var words = input.Split(delimiters);

            for (var i = 0; i < words.Length; i++)
            {
                if (string.IsNullOrEmpty(words[i]))
                    continue;

                var letters = words[i].ToCharArray();

                // Convert the first character of the word to uppercase
                if (char.IsLower(letters[0]))
                    letters[0] = char.ToUpper(letters[0]);

                // Convert the rest of the characters to lowercase
                for (var j = 1; j < letters.Length; j++)
                    if (char.IsUpper(letters[j]))
                        letters[j] = char.ToLower(letters[j]);

                words[i] = new string(letters);
            }

            return string.Join(" ", words);
        }
    }
}