using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClassProperty : ICodeElement, IDefinitionOf<IInterfaceProperty>
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
