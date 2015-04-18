using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.EnvDte;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain
{
    public class GoToInterfaceImplementationAlgorithm : IAlgorithm
    {
        public void Execute()
        {
            ICodeEditor codeEditor = Factory.Current.CreateCodeEditor();
            IInterface selectedInterface = codeEditor.GetSelectedCodeElement() as IInterface;

            if (selectedInterface == null)
            {
                return;
            }

            IInterfaceImplementationFinder finder = 
                Factory.Current.CreateInterfaceImplementationFinder(codeEditor);

            IEnumerable<IClass> selectedInterfaceImplementations = 
                selectedInterface.FindImplementations(finder);

            IInterfaceImplementationPresenter presenter =
                Factory.Current.CreateInterfaceImplementationPresenter(codeEditor);

            presenter.Present(selectedInterfaceImplementations);
        }
    }
}
