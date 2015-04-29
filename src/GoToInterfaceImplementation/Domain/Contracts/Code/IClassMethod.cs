using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassMethod :
        ISemanticElement,
        IExecutable,
        IDefinitionOf<IInterfaceMethod>,
        IMemberOf<IClass>
    {
    }
}
