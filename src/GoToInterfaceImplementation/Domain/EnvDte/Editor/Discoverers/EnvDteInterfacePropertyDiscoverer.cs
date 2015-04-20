using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class EnvDteInterfacePropertyDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfacePropertyDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
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
