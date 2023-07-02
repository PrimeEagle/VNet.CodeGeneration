﻿namespace VNet.CodeGeneration.Writers.StructuredWriter
{
    public interface IStructuredLanguageSyntax
    {
        string OpenScopeOpenSymbol { get; }
        string OpenScopeCloseSymbol { get; }
        string CloseScopeOpenSymbol { get; }
        string CloseScopeCloseSymbol { get; }


        bool IsValidNaming(string name);
    }
}