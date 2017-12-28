using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCallOperations
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return method.TypesOfOperations(
                o => o.IsCallOperation(), 
                o => o.CalleeTypes());
        }

        private static bool IsCallOperation(this OpCode o)
        {
            return o.Code == Code.Call
                || o.Code == Code.Calli
                || o.Code == Code.Callvirt;
        }

        private static IEnumerable<TypeReference> CalleeTypes(this Instruction o)
        {
            yield return (o.Operand as MemberReference).DeclaringType;
            if (o.Operand is GenericInstanceMethod)
                foreach (var genericArgument in GetGenericArguments(o))
                    yield return genericArgument;
        }
  
        private static IEnumerable<TypeReference> GetGenericArguments(Instruction o)
        {
            return (o.Operand as GenericInstanceMethod).GenericArguments;
        }
    }
}
