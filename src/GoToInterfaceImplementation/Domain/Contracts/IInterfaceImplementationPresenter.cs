using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceImplementationPresenter
    {
        void Present(IEnumerable<IClass> codeInterfaceImplementations);
    }
}
