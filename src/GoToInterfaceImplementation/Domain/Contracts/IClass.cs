using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClass : ICodeElement
    {
        IEnumerable<IInterface> ImplementedInterfaces { get; }
    }
}
