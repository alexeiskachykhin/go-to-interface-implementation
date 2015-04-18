using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterface : ICodeElement
    {
        IEnumerable<IClass> FindImplementations(IInterfaceImplementationFinder finder);
    }
}
