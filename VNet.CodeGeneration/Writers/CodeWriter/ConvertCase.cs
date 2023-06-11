using System.Globalization;
using System;
using System.Linq;

namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class ConvertCase
    {
        private static char[] delimiters = new char[] {' ', '_', '-', '.'};


        public static string ToPascal(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToTitleCase(words[i].ToLower());
            }

            return string.Concat(words);
        }

        public static string ToCamel(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                if (i == 0)
                {
                    words[i] = textInfo.ToLower(words[i]);
                }
                else
                {
                    words[i] = textInfo.ToTitleCase(words[i].ToLower());
                }
            }

            return string.Concat(words);
        }

        public static string ToTitle(string input)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string[] words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].ToLower();

                if (i > 0 && IsLowercaseWord(word))
                {
                    words[i] = word;
                }
                else
                {
                    words[i] = textInfo.ToTitleCase(word);
                }
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
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToLower(words[i].ToLower());
            }

            return string.Join("_", words);
        }

        public static string ToScreamingSnake(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToUpper(words[i].ToUpper());
            }

            return string.Join("_", words);
        }

        public static string ToKebab(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToLower(words[i].ToLower());
            }

            return string.Join("-", words);
        }

        public static string ToScreamingKebab(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToUpper(words[i].ToUpper());
            }

            return string.Join("-", words);
        }

        public static string ToAlLLower(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo; 
            
            return textInfo.ToLower(input.ToLower());
        }

        public static string ToAllUpper(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToUpper(input.ToUpper());
        }

        public static string ToTitleDot(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToTitleCase(words[i].ToLower());
            }

            return string.Join(".", words);
        }

        public static string ToLowerDot(string input)
        {
            var textInfo = CultureInfo.CurrentCulture.TextInfo;
            var words = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                words[i] = textInfo.ToLower(words[i].ToLower());
            }

            return string.Join(".", words);
        }
    }
}