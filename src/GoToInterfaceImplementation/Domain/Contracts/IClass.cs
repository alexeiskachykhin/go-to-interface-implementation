using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClass : ICodeElement, IDefinitionOf<IInterface>
    {
        IEnumerable<IInterface> ImplementedInterfaces { get; }

        IEnumerable<IClassMember> Members { get; }
    }
}
