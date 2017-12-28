using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class NumberOfFields
    {
        public static int Of(TypeDefinition type)
        {
            return type.Fields.Count(f => !f.IsGeneratedCode());
        }

        public static int NotStaticAndPublic(TypeDefinition type)
        {
            return type.Fields.Count(f 
                => !f.IsStatic 
                && f.IsPublic
                && !f.IsGeneratedCode());
        }
    }
}
