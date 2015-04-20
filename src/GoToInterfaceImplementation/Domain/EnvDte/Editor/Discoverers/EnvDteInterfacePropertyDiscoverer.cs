using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteInterfacePropertyDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfacePropertyDiscoverer(DTE dte)
            : base(
            dte,
            typeof(EnvDteInterfaceProperty),
            typeof(CodeProperty2),
            vsCMElement.vsCMElementProperty)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            return true;
        }
    }
}
