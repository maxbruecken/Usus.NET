using System;
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
            return Normalize.TypeName(ToStringWithGenericParameters(type));
        }

        private static string ToStringWithGenericParameters(TypeReference type)
        {
            if (type is GenericInstanceType)
            {
                var typeFullName = type.GetElementType().ToString();
                return typeFullName.Substring(0, typeFullName.IndexOf("`", StringComparison.InvariantCulture));
            }
            if (!type.HasGenericParameters) return type.ToString();
            return type + "[" + string.Join(",", type.GenericParameters.Select(p => p.Name).ToArray()) + "]";
        }

        public static string GetFullName(this TypeReference type)
        {
            return Normalize.TypeName(ToStringWithGenericParameters(type));
        }
    }
}
