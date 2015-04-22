using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceProperty : IExecutableSemanticElement, IDeclarationOf<IClassProperty>
    {
        IInterface Interface { get; }
    }
}
