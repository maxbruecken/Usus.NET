using System;
using System.Collections.Generic;
using System.Linq;
using EnvDTE80;

namespace andrena.Usus.net.ExtensionHelper
{
    public class BuildAwareToolWindowPane : SolutionEventsAwareToolWindowPane
    {
        public event Action<IEnumerable<string>> BuildSuccessfull;

        public BuildAwareToolWindowPane(IServiceProvider isp)
            : base(isp)
        {
            BuildSuccessfull += fs => { };
            BuildDone += OnBuildDone;
        }

        private void OnBuildDone(bool success)
        {
            if (success) BuildSuccessfull(FindCreatedFiles());
        }

        private IEnumerable<string> FindCreatedFiles()
        {
            return from p in Projects
                   where p.OutputAssembly.Exists
                   select p.OutputAssembly.FullName;
        }

        protected CompilerErrors GetErrors()
        {
            CompilerErrors errors = new CompilerErrors();
            if (MasterObjekt != null) AnalyzeErrorItems(errors);
            return errors;
        }

        private void AnalyzeErrorItems(CompilerErrors errors)
        {
            var list = MasterObjekt.ToolWindows.ErrorList;
            for (var index = 1; index <= list.ErrorItems.Count; index++)
            {
                AddUpErrors(errors, list.ErrorItems.Item(index));
            }
        }

        private void AddUpErrors(CompilerErrors errors, ErrorItem item)
        {
            switch (item.ErrorLevel)
            {
                case vsBuildErrorLevel.vsBuildErrorLevelHigh:
                    errors.ErrorCount++; break;
                case vsBuildErrorLevel.vsBuildErrorLevelMedium:
                case vsBuildErrorLevel.vsBuildErrorLevelLow:
                    errors.WarningCount++; break;
                default: break;
            }
        }
    }
}
