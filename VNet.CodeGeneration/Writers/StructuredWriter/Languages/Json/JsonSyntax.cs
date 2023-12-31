﻿// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
namespace VNet.CodeGeneration.Writers.StructuredWriter.Languages.Json
{
    public class JsonSyntax : IStructuredLanguageSyntax
    {
        public string OpenScopeOpenSymbol => "<";
        public string OpenScopeCloseSymbol => ">";
        public string CloseScopeOpenSymbol => "</";
        public string CloseScopeCloseSymbol => ">";
        public string ScopeListSeparatorSymbol => ",";


        public bool IsValidNaming(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;

            foreach (var c in name)
            {
                if (char.IsControl(c))
                    return false;
            }

            return true;
        }

    }
}