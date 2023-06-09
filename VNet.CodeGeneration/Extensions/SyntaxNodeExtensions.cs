using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace VNet.Scientific.CodeGen.Extensions
{
    public static class SyntaxNodeExtensions
    {
        public static string GetNamespace(this SyntaxNode node)
        {
            while (node != null)
            {
                if (node is BaseNamespaceDeclarationSyntax namespaceDeclaration)
                {
                    return namespaceDeclaration.Name.ToString();
                }
                node = node.Parent;
            }

            return null;
        }
    }
}