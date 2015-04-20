using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassMethod : ICodeElement, IDefinitionOf<IInterfaceMethod>
    {
        string ReturnTypeFullName { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
