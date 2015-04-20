using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteParameterOfInterfaceTypeDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteParameterOfInterfaceTypeDiscoverer(DTE dte)
            : base(
            dte,
            typeof(EnvDteParameterOfInterfaceType), 
            typeof(CodeParameter),
            vsCMElement.vsCMElementParameter)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            return true;
        }
    }
}
