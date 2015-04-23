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

            OleMenuCommand menuItem = new OleMenuCommand(OnCommandInvoke, commandId);
            menuItem.BeforeQueryStatus += OnBeforeQueryStatus;

            menuCommandService.AddCommand(menuItem);
        }


        private void OnCommandInvoke(object sender, EventArgs e)
        {
            Execute();
        }

        private void OnBeforeQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand menuItem = sender as OleMenuCommand;
            menuItem.Visible = CanExecute();
        }


        private async void Execute()
        {
            var algorithm = new GoToInterfaceImplementationAlgorithm();
            await algorithm.ExecuteAsync();
        }

        private bool CanExecute()
        {
            var algorithm = new GoToInterfaceImplementationAlgorithm();
            return algorithm.CanExecute();
        }
    }
}
