using andrena.Usus.net.Core.AssemblyNavigation;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class CyclomaticComplexityOfAst
    {
        public static int Of(MethodDefinition method, CSharpDecompiler decompiler)
        {
            if (method.HasOperations())
                return method.CalculateCyclomaticComplexity(decompiler);
            else
                return 0;
        }

        private static int CalculateCyclomaticComplexity(this MethodDefinition method, CSharpDecompiler decompiler)
        {
            var cyclomaticComplexityCalculator = new CyclomaticComplexityCalculator(decompiler);
            cyclomaticComplexityCalculator.Calculate(method);
            return cyclomaticComplexityCalculator.Result;
        }
    }
}
