using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassEvent : ISemanticElement, IDefinitionOf<IInterfaceEvent>, IMemberOf<IInterface>
    {
    }
}
