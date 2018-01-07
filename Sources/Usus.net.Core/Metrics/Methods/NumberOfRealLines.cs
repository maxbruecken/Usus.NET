using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfRealLines
    {
        public static int Of(MethodDefinition method)
        {
	        if (!method.HasBody) return 0;
            if (method.DebugInformation?.HasSequencePoints ?? false)
            {
                if (method.IsIterator()) return -1;
                var locations = method.LocatedOperations();
                return locations.DifferenceBetweenStartAndEndlines();
            }
            return -1;
        }

        private static int DifferenceBetweenStartAndEndlines(this IEnumerable<OperationLocation> locations)
        {
            if (!locations.GetAllValidLines(l => l.Line).Any()) return 0;
            var firstLine = locations.GetAllValidLines(l => l.Line).Min();
            var lastLine = locations.GetAllValidLines(l => l.Line).Where(l => l < 100000).Max();
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
