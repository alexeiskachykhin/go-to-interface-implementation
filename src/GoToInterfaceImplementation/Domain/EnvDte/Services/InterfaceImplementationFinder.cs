using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class InterfaceImplementationFinder : IImplementationFinder<IInterface, IClass>
    {
        private readonly ICodeEditor _codeEditor;


        public InterfaceImplementationFinder(ICodeEditor codeEditor)
        {
            _codeEditor = codeEditor;
        }


        public IEnumerable<IClass> Find(IInterface interfaceElement)
        {
            IEnumerable<IClass> classes = _codeEditor.GetClassesInSolution();

            IEnumerable<IClass> derivedCodeClasses = classes.Where(
                c => c.IsMatch(interfaceElement));

            return derivedCodeClasses;
        }
    }
}
