using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceMethod : IExecutableSemanticElement, IDeclarationOf<IClassMethod>
    {
        IInterface Interface { get; }
    }
}
