using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfLogicalLines
    {
        public static int Of(MethodDefinition method)
        {
	        if (!method.HasBody) return 0;
			if (method.IsIterator()) return -1;
            var locations = method.LocatedOperations();
            return locations.GetAllStartLinesOfInterestingOpCodes().Distinct().Count();
        }

        private static IEnumerable<int> GetAllStartLinesOfInterestingOpCodes(this IEnumerable<OperationLocation> locations)
        {
            return from l in locations
                   where l.OperationCode.IsOpCodeOfInterest() && l.IsValidLocation
                   select l.Location.Line;
        }

        private static bool IsOpCodeOfInterest(this OpCode opCode)
        {
            return opCode.Code != Code.Nop
                && opCode.Code != Code.Leave_S
                && opCode.Code != Code.Ret;
        }
    }
}
