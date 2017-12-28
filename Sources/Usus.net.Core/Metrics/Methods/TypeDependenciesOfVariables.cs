using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.AssemblyNavigation;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class TypeDependenciesOfVariables
    {
        public static IEnumerable<string> Of(MethodDefinition method)
        {
            return from v in method.Body.Variables
                   from t in GetTypesOfVariable(v)
                   select t;
        }

        private static IEnumerable<string> GetTypesOfVariable(VariableDefinition variable)
        {
            return from t in variable.VariableType.GetAllRealTypeReferences()
                   select t.ToString();
        }
    }
}
