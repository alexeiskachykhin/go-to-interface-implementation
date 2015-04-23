using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassProperty : 
        ISemanticElement, 
        IExecutable, 
        IDefinitionOf<IInterfaceProperty>, 
        IMemberOf<IClass>
    {
    }
}
