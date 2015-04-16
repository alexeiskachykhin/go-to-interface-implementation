using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace GoToInterfaceImplementation.Integration
{
    public class GoToInterfaceImplementationCommand
    {
        private readonly Func<Type, object> _serviceLocator;


        public GoToInterfaceImplementationCommand(Func<Type, object> serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }


        public void Register()
        {
            OleMenuCommandService menuCommandService = _serviceLocator(typeof(IMenuCommandService)) as OleMenuCommandService;

            if (menuCommandService == null)
            {
                return;
            }

            CommandID commandId = new CommandID(Identifiers.GoToInterfaceImplementationCmdSet, (int)Identifiers.GoToInterfaceImplementationCmd);
            MenuCommand menuItem = new MenuCommand((sender, e) => Execute(), commandId);
            menuCommandService.AddCommand(menuItem);
        }

        private void Execute()
        {
            // Show a Message Box to prove we were here
            IVsUIShell uiShell = (IVsUIShell)_serviceLocator(typeof(SVsUIShell));
            Guid clsid = Guid.Empty;
            int result;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "GoToInterfaceImplementation",
                       string.Format(CultureInfo.CurrentCulture, "Inside {0}.MenuItemCallback()", this.ToString()),
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,        // false
                       out result));
        }
    }
}
