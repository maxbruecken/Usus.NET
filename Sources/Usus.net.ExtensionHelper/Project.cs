using System;
using System.IO;
using System.Linq;
using EnvDTE;
using Microsoft.VisualStudio.PlatformUI;

namespace andrena.Usus.net.ExtensionHelper
{
    public class Project
    {
        public string Name { get; private set; }
        public string ProjectPath { get; private set; }
        public string ProjectFile { get; private set; }
        public FileInfo OutputAssembly { get; private set; }

        internal static bool IsValid(EnvDTE.Project project)
        {
            try
            {
                return project.Properties != null 
                    && !string.IsNullOrEmpty(project.FullName) 
                    && project.HasProperty("FullPath");
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal Project(EnvDTE.Project project)
        {
            Name = project.Name;
            ProjectFile = project.FullName;
            ProjectPath = project.GetPropertyString("FullPath");
            var outputPath = project.ConfigurationManager.ActiveConfiguration.Properties.Item("OutputPath").Value.ToString();
            var outputFileName = project.GetPropertyString("OutputFileName");
            if (string.IsNullOrEmpty(outputFileName))
            {
                var outputGroups = project.ConfigurationManager.ActiveConfiguration.OutputGroups;
                outputFileName = outputGroups
                    .OfType<OutputGroup>()
                    .SelectMany(g => ((Array) g.FileNames).OfType<string>())
                    .FirstOrDefault(n => n.EndsWith(".dll") || n.EndsWith(".exe"));
            }
            OutputAssembly = new FileInfo(Path.Combine(ProjectPath, outputPath, outputFileName));
        }
    }
}
