using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceProperty : ICodeElement, IDeclarationOf<IClassProperty>
    {
        IInterface Interface { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
