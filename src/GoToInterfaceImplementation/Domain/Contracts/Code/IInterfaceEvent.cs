using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceEvent : ICodeElement, IDeclarationOf<IClassEvent>
    {
        IInterface Interface { get; }
    }
}
