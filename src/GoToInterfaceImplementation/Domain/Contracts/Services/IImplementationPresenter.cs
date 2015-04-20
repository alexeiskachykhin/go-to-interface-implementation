using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IImplementationPresenter
    {
        void Present(IEnumerable<ICodeElement> codeElementImplementations);
    }
}
