using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Helper;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfCatches
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            if (!method.HasBody) return Enumerable.Empty<string>();
            return from e in method.Body.ExceptionHandlers
                   where e.HandlerType == ExceptionHandlerType.Catch
                   from t in e.CatchType.GetAllRealTypeReferences()
                   select t.GetFullName();
        }
    }
}