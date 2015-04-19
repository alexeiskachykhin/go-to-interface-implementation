using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClassEvent : ICodeElement, IDefinitionOf<IInterfaceEvent>
    {
    }
}
