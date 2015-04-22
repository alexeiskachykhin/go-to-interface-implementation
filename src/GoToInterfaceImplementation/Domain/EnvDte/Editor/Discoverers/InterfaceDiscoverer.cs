using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class InterfaceDiscoverer : SemanticElementDiscoverer
    {
        public InterfaceDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(Interface),
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
