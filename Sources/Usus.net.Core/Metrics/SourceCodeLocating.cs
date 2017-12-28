using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class SourceCodeLocating
    {
        public static SourceCodeLocation OfMethod(MethodDefinition method, CSharpDecompiler decompiler)
        {
            return Of(method, decompiler);
        }

        public static SourceCodeLocation OfType(TypeDefinition type, CSharpDecompiler decompiler)
        {
            return SourceCodeLocation.None;
        }

        private static SourceCodeLocation Of(this IMemberDefinition locatable, CSharpDecompiler decompiler)
        {
            var location = locatable.GetValidLocation(decompiler);
            return !location.IsEmpty ? locatable.ToSourceCodeLocation(decompiler) : SourceCodeLocation.None;
        }

        private static SourceCodeLocation ToSourceCodeLocation(this IMemberDefinition locatable, CSharpDecompiler decompiler)
        {
            return new SourceCodeLocation
            {
                Filename = decompiler.Decompile(locatable).FileName,
                Line = locatable.GetValidLocation(decompiler).Line
            };
        }

        private static TextLocation GetValidLocation(this IMemberDefinition locatable, CSharpDecompiler decompiler)
        {
            return decompiler == null ? TextLocation.Empty : locatable.GetValidLocations(decompiler).FirstOrDefault();
        }

        private static IEnumerable<TextLocation> GetValidLocations(this IMemberDefinition locatable, CSharpDecompiler decompiler)
        {
            return from c in decompiler.Decompile(locatable).Children
                   where c.HasChildren
                   select c.StartLocation;
        }
    }
}
