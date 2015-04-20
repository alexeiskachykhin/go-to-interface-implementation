using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class EnvDteInterfaceEvent : EnvDteCodeElement<CodeEvent>, IInterfaceEvent
    {
        public IInterface Interface
        {
            get { return new EnvDteInterface(CodeEditor, (CodeInterface)CodeElement.Parent); }
        }


        public EnvDteInterfaceEvent(ICodeEditor codeEditor, CodeEvent codeEvent)
            : base(codeEditor, codeEvent)
        {
        }


        public IEnumerable<IClassEvent> FindImplementations()
        {
            IImplementationFinder<IInterfaceEvent, IClassEvent> finder =
                new EnvDteInterfaceEventImplementationFinder();

            return finder.Find(this);
        }
    }
}
