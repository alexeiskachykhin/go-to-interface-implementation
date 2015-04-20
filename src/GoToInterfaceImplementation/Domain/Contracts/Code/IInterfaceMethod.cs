using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceMethod : ICodeElement, IDeclarationOf<IClassMethod>
    {
        IInterface Interface { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
