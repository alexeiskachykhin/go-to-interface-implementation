using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteInterfaceMethodDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfaceMethodDiscoverer(DTE dte)
            : base(
            dte,
            typeof(EnvDteInterfaceMethod), 
            typeof(CodeFunction),
            vsCMElement.vsCMElementFunction)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            return true;
        }
    }
}
