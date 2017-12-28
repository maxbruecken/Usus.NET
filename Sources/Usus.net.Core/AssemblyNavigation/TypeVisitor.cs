using System.Collections.Generic;
using System.Linq;
using andrena.Usus.net.Core.Reports;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal abstract class TypeVisitor : AssemblyVisitor
    {
        protected override void AnalyzeTypes(ModuleDefinition assembly, MetricsReport report, CSharpDecompiler decompiler)
        {
            foreach (var typeMetrics in AnalyzeTypes(assembly, decompiler))
                report.AddTypeReport(typeMetrics);
        }

        private IEnumerable<TypeMetricsWithMethodMetrics> AnalyzeTypes(ModuleDefinition assembly, CSharpDecompiler decompiler)
        {
            return from type in assembly.Types
                   where type.Name != "<Module>"
                   select TypeAndMethods(type, decompiler);
        }

        private TypeMetricsWithMethodMetrics TypeAndMethods(TypeDefinition type, CSharpDecompiler decompiler)
        {
            var typeAndMethods = new TypeMetricsWithMethodMetrics();
            typeAndMethods.AddMethodReports(AnalyzeMethods(type, decompiler));
            foreach (var nestedType in type.NestedTypes)
            {
                var nestedTypeAndMethods = TypeAndMethods(nestedType, decompiler);
                typeAndMethods.AddMethodReports(nestedTypeAndMethods.Methods);
            }
            typeAndMethods.Type = AnalyzeType(type, typeAndMethods.Methods, decompiler);
            return typeAndMethods;
        }

        private IEnumerable<MethodMetricsReport> AnalyzeMethods(TypeDefinition type, CSharpDecompiler decompiler)
        {
            return from method in type.Methods
                   select AnalyzeMethod(method, decompiler);
        }

        protected abstract TypeMetricsReport AnalyzeType(TypeDefinition type, IEnumerable<MethodMetricsReport> methods, CSharpDecompiler decompiler);

        protected abstract MethodMetricsReport AnalyzeMethod(MethodDefinition method, CSharpDecompiler decompiler);
    }
}
