using System.Linq;
using andrena.Usus.net.Core.Helper.Reflection;
using ICSharpCode.Decompiler;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Helper
{
    public static class TypeDefinitionExtensions
    {
        public static string GetFullName(this TypeDefinition type)
        {
            var fullTypeName = type.GetFullTypeName();
            return Normalize.TypeName(fullTypeName + GetGenericParameters(type));
        }

        private static string GetGenericParameters(IGenericParameterProvider type)
        {
            if (!type.HasGenericParameters) return string.Empty;
            return "[" + string.Join(",", type.GenericParameters.Select(p => p.Name).ToArray()) + "]";
        }

        public static string GetFullName(this TypeReference type)
        {
            var fullTypeName = type.ToString();
            return Normalize.TypeName(fullTypeName + GetGenericParameters(type));
        }
    }
}
