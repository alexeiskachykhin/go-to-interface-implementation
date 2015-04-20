using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteInterfaceEventDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfaceEventDiscoverer(DTE dte)
            : base(
            dte,
            typeof(EnvDteInterfaceEvent), 
            typeof(CodeEvent),
            vsCMElement.vsCMElementEvent)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            return true;
        }
    }
}
