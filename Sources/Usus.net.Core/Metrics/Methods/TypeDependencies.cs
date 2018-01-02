using System.Collections.Generic;
using System.Linq;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependencies
    {
        public static IEnumerable<string> Of(MethodDefinition method, CSharpDecompiler decompiler)
        {
            var typesOfSignature = TypeDependenciesOfSignature.Of(method).ToList();
            var typesOfVariables = TypeDependenciesOfVariables.Of(method).ToList();
            var typesOfCallOperations = TypeDependenciesOfCallOperations.Of(method).ToList();
            var typesOfNewOperations = TypeDependenciesOfNewOperations.Of(method).ToList();
            var typesOfCatches = TypeDependenciesOfCatches.Of(method).ToList();
            var typesOfTypeMentions = TypeDependenciesOfTypeMentions.Of(method).ToList();

            return Enumerable.Empty<string>()
                .Union(typesOfSignature)
                .Union(typesOfVariables)
                .Union(typesOfCallOperations)
                .Union(typesOfNewOperations)
                .Union(typesOfCatches)
                .Union(typesOfTypeMentions)
                .ToList();
        }
    }
}
