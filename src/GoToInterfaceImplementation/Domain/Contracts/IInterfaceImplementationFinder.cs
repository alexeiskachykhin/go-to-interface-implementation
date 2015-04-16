using System;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceImplementationFinder
    {
        IClass Find(IInterface codeInterface);
    }
}
