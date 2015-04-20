using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassProperty : ICodeElement, IDefinitionOf<IInterfaceProperty>
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
