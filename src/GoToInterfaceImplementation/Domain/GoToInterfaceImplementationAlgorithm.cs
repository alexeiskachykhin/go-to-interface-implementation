using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain
{
    public class GoToInterfaceImplementationAlgorithm : IAlgorithm
    {
        public async void Execute()
        {
            ICodeEditor codeEditor = Factory.Current.CreateCodeEditor();

            IDeclarationOf<ICodeElement> declaration = 
                codeEditor.GetSelectedCodeElement() as IDeclarationOf<ICodeElement>;

            if (declaration == null)
            {
                return;
            }

            IEnumerable<ICodeElement> declarationImplementations =
                declaration.FindImplementations();

            IImplementationSelector implementationSelector =
                Factory.Current.CreateImplementationSelector();

            ICodeElement declarationImplementation = await implementationSelector.SelectAsync(declarationImplementations);

            if (declarationImplementation != null)
            {
                declarationImplementation.RevealInCodeEditor();
            }
        }
    }
}
