using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClassMethod : ICodeElement, IDefinitionOf<IInterfaceMethod>
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
