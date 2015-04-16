using System;

using GoToInterfaceImplementation.Domain.EnvDte;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain
{
    public class GoToInterfaceImplementationAlgorithm : IAlgorithm
    {
        public void Execute()
        {
            ICodeEditor codeEditor = Factory.Current.Create<ICodeEditor>();
            IInterface selectedInterface = codeEditor.GetSelectedCodeElement() as IInterface;

            if (selectedInterface != null)
            {
                selectedInterface.RevealImplementationInCodeWindow();
            }
        }
    }
}
