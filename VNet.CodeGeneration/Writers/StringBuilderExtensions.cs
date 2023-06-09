using System.Text;
using System.Text.RegularExpressions;

namespace VNet.CodeGeneration.Writers
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendWithSpaces(this StringBuilder sb, string value, bool spaceBefore = false, bool spaceAfter = false)
        {
            if (string.IsNullOrEmpty(value))
                return sb;

            if (spaceBefore)
                sb.Append(' ');

            sb.Append(value);

            if (spaceAfter)
                sb.Append(' ');

            return sb;
        }

        public static StringBuilder AppendLineWithSpaces(this StringBuilder sb, string value, bool spaceBefore = false, bool spaceAfter = false)
        {
            sb.AppendWithSpaces(value, spaceBefore, spaceAfter);
            sb.AppendLine();
            return sb;
        }

        public static string ApplyWhitespaceSettings(this string code, ILanguageSettings languageSettings)
        {
            if (!languageSettings.Style.SpaceInsideParentheses)
                code = Regex.Replace(code, @"\(\s+", "(");

            if (!languageSettings.Style.SpaceOutsideParentheses)
                code = Regex.Replace(code, @"\s+\)", ")");

            if (!languageSettings.Style.SpaceAfterComma)
                code = Regex.Replace(code, @",\s+", ",");

            return code;
        }
    }
}