using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteInterfaceDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfaceDiscoverer(DTE dte)
            : base(
            dte,
            typeof(EnvDteInterface),
            typeof(CodeInterface),
            vsCMElement.vsCMElementInterface)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            return true;
        }
    }
}
