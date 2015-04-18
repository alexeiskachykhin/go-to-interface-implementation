using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceImplementationPresenter : IInterfaceImplementationPresenter
    {
        private ICodeEditor _codeEditor;


        public EnvDteInterfaceImplementationPresenter(ICodeEditor codeEditor)
        {
            _codeEditor = codeEditor;
        }


        public void Present(IEnumerable<IClass> codeInterfaceImplementations)
        {
            IClass codeInterfaceImplementation = codeInterfaceImplementations.FirstOrDefault();

            if (codeInterfaceImplementation != null)
            {
                codeInterfaceImplementation.RevealInCodeEditor();
            }
        }
    }
}
