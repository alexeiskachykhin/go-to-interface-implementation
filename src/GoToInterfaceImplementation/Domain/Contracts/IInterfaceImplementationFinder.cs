using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceImplementationFinder
    {
        IEnumerable<IClass> Find(IInterface codeInterface);
    }
}
