using System;
using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Reports;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics
{
    internal static class SourceCodeLocating
    {
        public static SourceCodeLocation OfMethod(MethodDefinition method)
        {
            if (method.DebugInformation?.HasSequencePoints ?? false)
            {
                var locations = method.LocatedOperations();
                return new SourceCodeLocation
                {
                    Filename = method.DebugInformation.SequencePoints.FirstOrDefault(p => !string.IsNullOrEmpty(p.Document.Url))?.Document.Url,
                    Line = locations.GetAllValidLines(l => l.Line).Min()
                };
            }
			return SourceCodeLocation.None;
		}

        public static SourceCodeLocation OfType(TypeDefinition type)
        {
            return SourceCodeLocation.None;
        }

        private static IEnumerable<int> GetAllValidLines(this IEnumerable<OperationLocation> locations, Func<TextLocation, int> line)
        {
            return from l in locations
                where l.IsValidLocation
                select line(l.Location);
        }
    }
}
