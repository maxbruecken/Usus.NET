using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfNewOperations
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return method.TypesOfOperations(
                o => o.Code == Code.Newobj, 
                o => o.NeweeTypes());
        }

        private static IEnumerable<TypeReference> NeweeTypes(this Instruction o)
        {
            yield return (o.Operand as MemberReference).DeclaringType;
        }
    }
}
