using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Pdb;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfLogicalLines
    {
        public static int Of(MethodDefinition method, PdbReader pdb)
        {
            if (pdb != null)
            {
                if (pdb.IsIterator(method.Body)) return -1;
                var locations = method.LocatedOperations(pdb);
                return locations.GetAllStartLinesOfInterestingOpCodes().Distinct().Count();
            }
            return -1;
        }

        private static IEnumerable<int> GetAllStartLinesOfInterestingOpCodes(this IEnumerable<OperationLocation> locations)
        {
            return from l in locations
                   where l.OperationCode.IsOpCodeOfInterest() && l.IsValidLocation
                   select l.Location.StartLine;
        }

        private static bool IsOpCodeOfInterest(this OpCode opCode)
        {
            return opCode.Code != Code.Nop
                && opCode.Code != Code.Leave_S
                && opCode.Code != Code.Ret;
        }
    }
}
