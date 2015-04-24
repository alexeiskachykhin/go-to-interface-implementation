using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceProperty : 
        IProperty,
        IDeclarationOf<IClassProperty>,
        IMemberOf<IInterface>
    {
    }
}
