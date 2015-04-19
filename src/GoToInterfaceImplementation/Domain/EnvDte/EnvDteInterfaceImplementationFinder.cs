using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceImplementationFinder : IImplementationFinder<IInterface, IClass>
    {
        private readonly ICodeEditor _codeEditor;


        public EnvDteInterfaceImplementationFinder(ICodeEditor codeEditor)
        {
            _codeEditor = codeEditor;
        }


        public IEnumerable<IClass> Find(IInterface codeInterface)
        {
            IEnumerable<IClass> codeClasses = _codeEditor.GetClassesInSolution();

            IEnumerable<IClass> derivedCodeClasses = codeClasses.Where(
                c => c.IsMatch(codeInterface));

            return derivedCodeClasses;
        }
    }
}
