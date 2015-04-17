using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceImplementationFinder : IInterfaceImplementationFinder
    {
        private readonly ICodeEditor _codeEditor;


        public EnvDteInterfaceImplementationFinder(ICodeEditor codeEditor)
        {
            _codeEditor = codeEditor;
        }


        public IClass Find(IInterface codeInterface)
        {
            IEnumerable<IClass> codeClasses = _codeEditor.GetClassesInSolution();

            IClass derivedCodeClass =
                codeClasses.FirstOrDefault(c => c.ImplementedInterfaces.Any(b => b.FullName == codeInterface.FullName));

            return derivedCodeClass;
        }
    }
}
