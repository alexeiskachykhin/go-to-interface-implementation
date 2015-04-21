using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassMethod : IExecutableCodeElement, IDefinitionOf<IInterfaceMethod>
    {
    }
}
