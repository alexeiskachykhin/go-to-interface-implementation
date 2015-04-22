using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class Interface : SemanticElement<CodeInterface>, IInterface
    {
        public Interface(ICodeEditor codeEditor, CodeInterface codeInterface)
            : base(codeEditor, codeInterface)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IInterface, IClass> finder = 
                new InterfaceImplementationFinder(CodeEditor);

            return finder.Find(this);
        }
    }
}
