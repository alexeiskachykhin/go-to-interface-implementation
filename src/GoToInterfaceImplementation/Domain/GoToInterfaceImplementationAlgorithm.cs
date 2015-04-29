using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GoToInterfaceImplementation.Domain.Contracts;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain
{
    public class GoToInterfaceImplementationAlgorithm : IAlgorithm
    {
        public async Task ExecuteAsync()
        {
            ICodeEditor codeEditor = AbstractFactory.Current.CreateCodeEditor();

            IDeclarationOf<ISemanticElement> declaration =
                codeEditor.GetSelectedSemanticElement() as IDeclarationOf<ISemanticElement>;

            if (declaration == null)
            {
                return;
            }

            IEnumerable<ISemanticElement> declarationImplementations =
                declaration.FindImplementations();

            IImplementationSelector implementationSelector =
                AbstractFactory.Current.CreateImplementationSelector();

            ISemanticElement declarationImplementation = await implementationSelector.SelectAsync(declarationImplementations);

            if (declarationImplementation != null)
            {
                declarationImplementation.RevealInCodeEditor();
            }
        }

        public bool CanExecute()
        {
            ICodeEditor codeEditor = AbstractFactory.Current.CreateCodeEditor();

            IDeclarationOf<ISemanticElement> declaration =
                codeEditor.GetSelectedSemanticElement() as IDeclarationOf<ISemanticElement>;

            return (declaration != null);
        }
    }
}
