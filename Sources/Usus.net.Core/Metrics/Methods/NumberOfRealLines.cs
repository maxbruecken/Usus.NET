using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfRealLines
    {
        public static int Of(MethodDefinition method, CSharpDecompiler decompiler)
        {
            if (decompiler != null)
            {
                if (false/*pdb.IsIterator(method.Body)*/) return -1; // ToDo mb
                var locations = method.LocatedOperations(decompiler);
                return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<OperationLocation> locations)
        {
            if (!locations.GetAllValidLines(l => l.Line).Any()) return 0;
            var firstLine = locations.GetAllValidLines(l => l.Line).Min();
            var lastLine = locations.GetAllValidLines(l => l.Line).Max();
            return System.Math.Max(0, lastLine - firstLine - 1);
        }

        private static IEnumerable<int> GetAllValidLines(this IEnumerable<OperationLocation> locations, Func<TextLocation, int> line)
        {
            return from l in locations
                   where l.IsValidLocation
                   select line(l.Location);
        }
    }
}
