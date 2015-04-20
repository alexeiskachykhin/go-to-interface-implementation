using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassMethod : ICodeElement, IDefinitionOf<IInterfaceMethod>
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
