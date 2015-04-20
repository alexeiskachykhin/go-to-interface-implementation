using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteImplementationPresenter : IImplementationPresenter
    {
        public void Present(IEnumerable<ICodeElement> codeElementImplementations)
        {
            ICodeElement codeElementImplementation = codeElementImplementations.FirstOrDefault();

            if (codeElementImplementation != null)
            {
                codeElementImplementation.RevealInCodeEditor();
            }
        }
    }
}
