using System.IO;
using andrena.Usus.net.Core.Reports;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal abstract class AssemblyVisitor
    {
        public MetricsReport Report { get; private set; }

        public void Analyze(string assemblyPath)
        {
            Report = new MetricsReport();
            var moduleDefinition = ModuleDefinition.ReadModule(assemblyPath);
            var decompiler = new CSharpDecompiler(assemblyPath, new DecompilerSettings
            {
                AnonymousMethods = true,
                AnonymousTypes = true,
                AsyncAwait = true,
                AlwaysUseBraces = true,
                AutomaticEvents = true,
                AutomaticProperties = true,
                ExpressionTrees = true,
                ForEachStatement = true,
                ObjectOrCollectionInitializers = true
            });
            TryToAnalyze(assemblyPath, moduleDefinition, decompiler);
        }

        private void TryToAnalyze(string toAnalyze, ModuleDefinition moduleDefinition, CSharpDecompiler decompiler)
        {
            Analyze(toAnalyze, moduleDefinition, decompiler);
        }

        private void Analyze(string toAnalyse, ModuleDefinition moduleDefinition, CSharpDecompiler decompiler)
        {
            var pdbPath = GetProgramDatabasePath(toAnalyse);
            AnalyzeAssembly(moduleDefinition, pdbPath, decompiler);
        }

        private static string GetProgramDatabasePath(string toAnalyse)
        {
            string pdbFile = Path.ChangeExtension(toAnalyse, "pdb");
            return File.Exists(pdbFile) ? pdbFile : null;
        }

        private void AnalyzeAssembly(ModuleDefinition assembly, string pdbPath, CSharpDecompiler decompiler)
        {
            LoadSymbols(assembly, pdbPath);
            AnalyzeTypes(assembly, Report, decompiler);
        }

        private static void LoadSymbols(ModuleDefinition module, string pdbPath)
        {
            if (!module.HasDebugHeader || pdbPath == null)
            {
                return;
            }
            
            using (Stream s = File.OpenRead(pdbPath))
            {
                module.ReadSymbols(new Mono.Cecil.Pdb.PdbReaderProvider().GetSymbolReader(module, s));
            }
        }

        protected abstract void AnalyzeTypes(ModuleDefinition assembly, MetricsReport report, CSharpDecompiler decompiler);
    }
}
