using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCatches
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return from e in method.Body.ExceptionHandlers
                   from t in e.CatchType.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}