using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeExtensions
    {
        public static string FullName(this TypeDefinition type)
        {
            string typeName = type.IsGeneric ? type.InstanceType.ToString() : type.ToString();
            return typeName.Replace(", ", ",");
        }

        public static string Name(this TypeDefinition type)
        {
            return type.Name;
        }
    }
}
