using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IClassProperty :
        IProperty,
        IDefinitionOf<IInterfaceProperty>,
        IMemberOf<IClass>
    {
    }
}
