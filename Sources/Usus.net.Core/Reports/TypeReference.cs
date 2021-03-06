using System.Collections.Generic;
using System.Linq;

namespace andrena.Usus.net.Core.Reports
{
	public class TypeReference
	{
		private readonly MetricsReport metrics;

		public TypeMetricsReport Source { get; private set; }
		public TypeMetricsReport Target { get; private set; }
		public NamespaceMetricsReport SourceNamespace
		{
			get { return metrics.ForNamespace(Source.Namespaces.First()); }
		}
		public NamespaceMetricsReport TargetNamespace
		{
			get { return metrics.ForNamespace(Target.Namespaces.First()); }
		}

		public TypeReference(MetricsReport metrics, TypeMetricsReport source, TypeMetricsReport target)
		{
			this.metrics = metrics;
			this.Source = source;
			this.Target = target;
		}

		public IEnumerable<MethodMetricsReport> ReferencingMethods()
		{
			return from method in metrics.MethodsOfType(Source)
				   where method.TypeDependencies.Contains(Target.FullName)
				   select method;
		}
	}
}