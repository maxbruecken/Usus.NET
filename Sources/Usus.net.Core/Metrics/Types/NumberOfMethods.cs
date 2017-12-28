using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfMethods
    {
        public static int Of(TypeDefinition type)
        {
            return type.Methods.Count(m => !m.IsDefaultCtor());
        }
    }
}
