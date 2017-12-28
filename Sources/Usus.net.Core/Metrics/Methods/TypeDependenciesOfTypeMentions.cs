using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfTypeMentions
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return method.TypesOfOperations(
                o => o.IsTypeMentionOperation(),
                o => o.TypeMentionType());
        }

        private static bool IsTypeMentionOperation(this OpCode o)
        {
            return o.Code == Code.Isinst
                || o.Code == Code.Castclass
                || o.Code == Code.Box
                || o.Code == Code.Ldtoken;
        }

        private static IEnumerable<TypeReference> TypeMentionType(this Instruction o)
        {
            if (o.Operand is TypeReference)
                yield return o.Operand as TypeReference;
        }
    }
}
