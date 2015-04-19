using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceEvent : ICodeElement, IDeclarationOf<IClassEvent>
    {
        IInterface Interface { get; }
    }
}
