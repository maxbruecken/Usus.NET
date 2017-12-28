using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Helper;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfSignature
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return Enumerable.Empty<string>()
                .Union(method.ReturnTypes())
                .Union(method.ParameterTypes())
                .Union(method.TypesOfGenericsConstraints())
                .ToList();
        }

        private static IEnumerable<string> ReturnTypes(this MethodDefinition method)
        {
            return from t in method.ReturnType.GetAllRealTypeReferences()
                   select t.GetFullName();
        }

        private static IEnumerable<string> ParameterTypes(this MethodDefinition method)
        {
            return from p in method.Parameters
                   from t in p.ParameterType.GetAllRealTypeReferences()
                   where !t.IsGenericParameter
                   select t.GetFullName();
        }

        private static IEnumerable<string> TypesOfGenericsConstraints(this MethodDefinition method)
        {
            return from g in method.GenericParameters
                   from c in g.Constraints
                   from t in c.GetAllRealTypeReferences()
                   select t.GetFullName();
        }
    }
}
