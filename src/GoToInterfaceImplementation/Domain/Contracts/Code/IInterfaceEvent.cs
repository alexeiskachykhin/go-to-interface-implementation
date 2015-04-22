using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceEvent : ISemanticElement, IDeclarationOf<IClassEvent>
    {
        IInterface Interface { get; }
    }
}
