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

            IDeclarationOf<ICodeElement> selectedDeclaration = 
                codeEditor.GetSelectedCodeElement() as IDeclarationOf<ICodeElement>;

            if (selectedDeclaration == null)
            {
                return;
            }

            IEnumerable<ICodeElement> selectedDeclarationImplementations =
                selectedDeclaration.FindImplementations();

            IImplementationPresenter presenter =
                Factory.Current.CreateImplementationPresenter();

            presenter.Present(selectedDeclarationImplementations);
        }
    }
}
