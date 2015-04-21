using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceMethod : IExecutableCodeElement, IDeclarationOf<IClassMethod>
    {
        IInterface Interface { get; }
    }
}
