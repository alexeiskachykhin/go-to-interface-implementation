using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterface : EnvDteCodeElement<CodeInterface>, IInterface
    {
        public EnvDteInterface(ICodeEditor codeEditor, CodeInterface codeInterface)
            : base(codeEditor, codeInterface)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IInterface, IClass> finder = 
                new EnvDteInterfaceImplementationFinder(CodeEditor);

            return finder.Find(this);
        }
    }
}
