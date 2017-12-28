using ICSharpCode.Decompiler;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class GeneratedExtensions
    {
        public static bool IsGeneratedCode(this ICustomAttributeProvider r)
        {
            return r.IsCompilerGenerated() 
                || r.HasWeirdName();
        }

        private static bool HasWeirdName(this ICustomAttributeProvider r)
        {
            return r.ToString().Contains("<>");
        }
    }
}
