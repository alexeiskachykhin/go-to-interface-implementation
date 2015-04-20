using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
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
