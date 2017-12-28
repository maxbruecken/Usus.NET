using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Reports;
using Mono.Cecil;
using TypeReference = Mono.Cecil.TypeReference;

namespace andrena.Usus.net.Core.Metrics.Types
{
    internal static class DirectDependencies
    {
        public static IEnumerable<string> Of(TypeDefinition type, IEnumerable<MethodMetricsReport> methods)
        {
            var typesOfMethods = GetMethodTypes(methods).ToList();
            var typesOfFields = GetFieldTypes(type.Fields).ToList();
            var typesOfAncestors = GetAncestorTypes(type).ToList();
            var typesOfGenerics = GetGenericConstraints(type).ToList();

            return Enumerable.Empty<string>()
                .Union(type.FullName.Return())
                .Union(typesOfMethods)
                .Union(typesOfFields)
                .Union(typesOfAncestors)
                .Union(typesOfGenerics)
                .ToList();
        }

        private static IEnumerable<string> GetMethodTypes(IEnumerable<MethodMetricsReport> methods)
        {
            return from m in methods
                   from td in m.TypeDependencies
                   select td;
        }

        private static IEnumerable<string> GetFieldTypes(IEnumerable<FieldDefinition> fields)
        {
            return from f in fields
                   from t in f.FieldType.GetAllRealTypeReferences()
                   select t.ToString();
        }

        private static IEnumerable<string> GetAncestorTypes(TypeDefinition type)
        {
            return from c in type.BaseClasses().Concat(type.Interfaces.Select(i => i.InterfaceType))
                   from t in c.GetAllRealTypeReferences()
                   select t.ToString();
        }

        private static IEnumerable<TypeReference> BaseClasses(this TypeDefinition type)
        {
            return new[] {type.BaseType}; // ToDo mb
        }

        private static IEnumerable<string> GetGenericConstraints(TypeDefinition type)
        {
            return from g in type.GenericParameters
                   from c in g.Constraints
                   from t in c.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}
