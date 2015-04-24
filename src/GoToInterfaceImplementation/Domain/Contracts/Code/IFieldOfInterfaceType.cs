using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IFieldOfInterfaceType : IField, IDeclarationOf<IClass>
    {
        IInterface Interface { get; }
    }
}
