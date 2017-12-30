using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Helper;
using ICSharpCode.Decompiler;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class NamespaceExtensions
    {
        public static IEnumerable<string> Namespaces(this TypeDefinition type)
        {
            return AllNamespaces(type).ToList(n => n);
        }

        private static IEnumerable<string> AllNamespaces(this TypeDefinition type)
        {
            if (type.IsNested) return type.DeclaringType.AllNamespaces();
            var namespaceParts = type.Namespace.Split('.');
            return Combine(namespaceParts).Reverse();
        }

        private static IEnumerable<string> Combine(this IEnumerable<string> parts)
        {
            if (!parts.Any()) yield break;

            var result = string.Empty;
            var enumerator = parts.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result = result + (string.IsNullOrEmpty(result) ? string.Empty : ".") + enumerator.Current;
                yield return result;
            }
        }
    }
}
