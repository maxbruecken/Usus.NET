using System.Collections.Generic;
using andrena.Usus.net.Core.AssemblyNavigation;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Metrics.Methods;
using andrena.Usus.net.Core.Metrics.Types;
using andrena.Usus.net.Core.Reports;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;
using TypeVisitor = andrena.Usus.net.Core.AssemblyNavigation.TypeVisitor;

namespace andrena.Usus.net.Core.Metrics
{
    internal class MetricsCollector : TypeVisitor
    {
        protected override TypeMetricsReport AnalyzeType(TypeDefinition type, IEnumerable<MethodMetricsReport> methods, CSharpDecompiler decompiler)
        {
            return new TypeMetricsReport
            {
                Name = type.Name,
                FullName = type.GetFullName(),
                SourceLocation = SourceCodeLocating.OfType(type),
                Namespaces = type.Namespaces(),
                CompilerGenerated = type.IsGeneratedCode(),
                NumberOfFields = NumberOfFields.Of(type),
                NumberOfNonStaticPublicFields = NumberOfFields.NotStaticAndPublic(type),
                NumberOfMethods = NumberOfMethods.Of(type),
                DirectDependencies = DirectDependencies.Of(type, methods)
            };
        }

        protected override MethodMetricsReport AnalyzeMethod(MethodDefinition method, CSharpDecompiler decompiler)
        {
            return new MethodMetricsReport
            {
                Name = method.Name,
                Signature = method.Signature(),
                CompilerGenerated = method.IsGeneratedCode(),
                OnlyDeclaration = method.IsOnlyDeclaration(),
                DefaultConstructor = method.IsDefaultCtor(),
                SourceLocation = SourceCodeLocating.OfMethod(method),
                CyclomaticComplexity = CyclomaticComplexityOfAst.Of(method, decompiler),
                NumberOfStatements = NumberOfStatements.Of(method, decompiler),
                NumberOfRealLines = NumberOfRealLines.Of(method),
                NumberOfLogicalLines = NumberOfLogicalLines.Of(method),
                TypeDependencies = TypeDependencies.Of(method, decompiler)
            };
        }
    }
}