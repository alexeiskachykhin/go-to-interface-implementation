using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.Contracts.Services
{
    public interface IImplementationPresenter
    {
        void Present(IEnumerable<ICodeElement> codeElementImplementations);
    }
}
