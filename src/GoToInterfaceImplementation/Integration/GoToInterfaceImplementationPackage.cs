using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;

namespace GoToInterfaceImplementation.Integration
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageIdentifiers.GoToInterfaceImplementationPackageString)]
    public sealed class GoToInterfaceImplementationPackage : Package
    {
        public GoToInterfaceImplementationPackage()
        {
            PackageServiceLocator.Current = new PackageServiceLocator(GetService);
        }


        protected override void Initialize()
        {
            base.Initialize();

            var goToImplementationCommand = new GoToInterfaceImplementationCommand();
            goToImplementationCommand.Register();
        }
    }
}
