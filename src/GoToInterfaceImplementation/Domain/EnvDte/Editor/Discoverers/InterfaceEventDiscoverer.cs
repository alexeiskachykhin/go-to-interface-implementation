using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class InterfaceEventDiscoverer : SemanticElementDiscoverer
    {
        public InterfaceEventDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(InterfaceEvent), 
            typeof(CodeEvent),
            vsCMElement.vsCMElementEvent)
        {
        }


        protected override bool IsApplicable(CodeElement codeElement)
        {
            CodeEvent codeEvent = codeElement as CodeEvent;
            return (codeEvent.Parent is CodeInterface);
        }
    }
}
