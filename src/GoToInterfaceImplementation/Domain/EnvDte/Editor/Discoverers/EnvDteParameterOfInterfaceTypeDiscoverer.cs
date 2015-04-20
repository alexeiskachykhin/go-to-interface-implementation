using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    public class EnvDteParameterOfInterfaceTypeDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteParameterOfInterfaceTypeDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
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
