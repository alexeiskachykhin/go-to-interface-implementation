using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceMethod : ICodeElement, IDeclarationOf<IClassMethod>
    {
        IInterface Interface { get; }

        string ReturnTypeFullName { get;  }

        IEnumerable<IParameter> Parameters { get; }
    }
}
