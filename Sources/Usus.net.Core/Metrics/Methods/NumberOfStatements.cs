using andrena.Usus.net.Core.AssemblyNavigation;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfStatements
    {
        public static int Of(MethodDefinition method, CSharpDecompiler decompiler)
        {
            if (method.HasOperations())
                return method.CalculateStatements(decompiler);
            else
                return 0;
        }

        private static int CalculateStatements(this MethodDefinition method, CSharpDecompiler decompiler)
        {
            var statementCollector = new StatementCollector(decompiler);
            statementCollector.Collect(method);
            return statementCollector.ResultCount;
        }
    }
}
