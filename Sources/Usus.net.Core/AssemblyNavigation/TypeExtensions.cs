using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeExtensions
    {
        public static string FullName(this TypeDefinition type)
        {
            var typeName = type.HasGenericParameters ? type.FullNameWithGenericParameters() : type.ToString();
            return typeName.Replace(", ", ",");
        }

        public static string Name(this TypeDefinition type)
        {
            return type.Name;
        }

        public static string FullNameWithGenericParameters(this TypeDefinition type)
        {
            var astType = CSharpDecompiler.ConvertType(type, null, ConvertTypeOptions.DoNotUsePrimitiveTypeNames | ConvertTypeOptions.IncludeTypeParameterDefinitions);
            return astType.ToString();
        }
    }
}
