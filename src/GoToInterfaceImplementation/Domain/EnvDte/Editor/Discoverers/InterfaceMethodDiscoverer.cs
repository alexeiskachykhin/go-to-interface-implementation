using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class InterfaceMethodDiscoverer : CodeElementDiscoverer
    {
        public InterfaceMethodDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
            typeof(InterfaceMethod), 
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
