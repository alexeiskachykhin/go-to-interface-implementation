﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Editor.Discoverers
{
    internal class EnvDteInterfaceEventDiscoverer : EnvDteCodeElementDiscoverer
    {
        public EnvDteInterfaceEventDiscoverer(ICodeEditor codeEditor)
            : base(
            codeEditor,
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
