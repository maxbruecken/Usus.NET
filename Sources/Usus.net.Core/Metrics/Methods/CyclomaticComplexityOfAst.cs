using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Pdb;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class CyclomaticComplexityOfAst
    {
        public static int Of(MethodDefinition method, PdbReader pdb)
        {
            if (method.HasOperations())
                return method.CalculateCyclomaticComplexity(pdb);
            else
                return 0;
        }

        private static int CalculateCyclomaticComplexity(this MethodDefinition method, PdbReader pdb)
        {
            var methodBody = method.Decompile();
            var cyclomaticComplexityCalculator = new CyclomaticComplexityCalculator(pdb, null);
            cyclomaticComplexityCalculator.Traverse(methodBody.Statements());
            return cyclomaticComplexityCalculator.Result;
        }
    }
}
