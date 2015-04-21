using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassProperty : IExecutableCodeElement, IDefinitionOf<IInterfaceProperty>
    {
    }
}
