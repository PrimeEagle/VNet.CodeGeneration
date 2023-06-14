using Microsoft.CodeAnalysis;

namespace VNet.CodeGeneration.Extensions
{
    public static class GeneratorExecutionContextExtensions
    {
        public static string ProjectDir(this GeneratorExecutionContext context)
        {
            return context.AnalyzerConfigOptions.GlobalOptions.TryGetValue("build_property.projectdir", out var result) ? result : null;
        }
    }
}