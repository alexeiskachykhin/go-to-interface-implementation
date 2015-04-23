using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceProperty : 
        ISemanticElement, 
        IExecutable, 
        IDeclarationOf<IClassProperty>,
        IMemberOf<IInterface>
    {
        IInterface Interface { get; }
    }
}
