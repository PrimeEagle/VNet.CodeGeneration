namespace VNet.CodeGeneration.Writers.CodeWriter
{
    public static class CodeWriterExtensions
    {
        public static string ApplyWhitespaceSettings(this string code, IProgrammingLanguageSettings languageSettings)
        {
            // Apply whitespace settings to the code string
            if (languageSettings.Style.SpaceAroundOperators)
            {
                // Apply spaces around operators
                code = code.Replace("=", " = ").Replace("+", " + ").Replace("-", " - ").Replace("*", " * ").Replace("/", " / ");
            }

            if (languageSettings.Style.SpaceInsideParentheses)
            {
                // Apply spaces inside parentheses
                code = code.Replace("(", "( ").Replace(")", " )");
            }

            if (languageSettings.Style.SpaceOutsideParentheses)
            {
                // Apply spaces outside parentheses
                code = code.Replace(" (", "(").Replace(") ", ")");
            }

            if (languageSettings.Style.SpaceAfterComma)
            {
                // Apply space after commas
                code = code.Replace(",", ", ");
            }

            return code;
        }
    }
}