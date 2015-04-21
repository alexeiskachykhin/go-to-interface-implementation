using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using GoToInterfaceImplementation.Domain;

namespace GoToInterfaceImplementation.Integration
{
    public class GoToInterfaceImplementationCommand
    {
        public void Register()
        {
            OleMenuCommandService menuCommandService = PackageServiceLocator.Current.GetService<IMenuCommandService, OleMenuCommandService>();

            if (menuCommandService == null)
            {
                return;
            }

            CommandID commandId = new CommandID(
                PackageIdentifiers.GoToInterfaceImplementationCommandSet, 
                (int)PackageIdentifiers.GoToInterfaceImplementationCommand);

            MenuCommand menuItem = new MenuCommand((sender, e) => Execute(), commandId);
            menuCommandService.AddCommand(menuItem);
        }

        private async void Execute()
        {
            var algorithm = new GoToInterfaceImplementationAlgorithm();
            await algorithm.ExecuteAsync();
        }
    }
}
