using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Helper;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCatches
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return from e in method.Resolve().Body.ExceptionHandlers
                   from t in e.CatchType.GetAllRealTypeReferences()
                   select t.GetFullName();
        }
    }
}