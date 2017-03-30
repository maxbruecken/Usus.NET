using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using Microsoft.Cci;
using Mono.Cecil;
using Mono.Cecil.Pdb;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal abstract class TypeVisitor : AssemblyVisitor
    {
        protected override void AnalyzeTypes(IAssembly assembly, PdbReader pdb, IMetadataHost host, MetricsReport report)
        {
            foreach (var typeMetrics in AnalyzeTypes(assembly, pdb, host))
                report.AddTypeReport(typeMetrics);
        }

        private IEnumerable<TypeMetricsWithMethodMetrics> AnalyzeTypes(IAssembly assembly, PdbReader pdb, IMetadataHost host)
        {
            return from type in assembly.GetAllTypes()
                   where type.Name.ToString() != "<Module>"
                   select TypeAndMethods(pdb, host, type);
        }

        private TypeMetricsWithMethodMetrics TypeAndMethods(PdbReader pdb, IMetadataHost host, TypeDefinition type)
        {
            var typeAndMethods = new TypeMetricsWithMethodMetrics();
            typeAndMethods.AddMethodReports(AnalyzeMethods(type, pdb, host));
            foreach (var nestedType in type.NestedTypes)
            {
                var nestedTypeAndMethods = TypeAndMethods(pdb, host, nestedType);
                typeAndMethods.AddMethodReports(nestedTypeAndMethods.Methods);
            }
            typeAndMethods.Type = AnalyzeType(type, pdb, typeAndMethods.Methods);
            return typeAndMethods;
        }

        private IEnumerable<MethodMetricsReport> AnalyzeMethods(TypeDefinition type, PdbReader pdb, IMetadataHost host)
        {
            return from method in type.Methods
                   select AnalyzeMethod(method, pdb, host);
        }

        protected abstract TypeMetricsReport AnalyzeType(TypeDefinition type, PdbReader pdb, IEnumerable<MethodMetricsReport> methods);
        protected abstract MethodMetricsReport AnalyzeMethod(MethodDefinition method, PdbReader pdb, IMetadataHost host);
    }
}
