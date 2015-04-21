using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceProperty : IExecutableCodeElement, IDeclarationOf<IClassProperty>
    {
        IInterface Interface { get; }
    }
}
