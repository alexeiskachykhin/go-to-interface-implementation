using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterfaceMethod :
        ISemanticElement,
        IExecutable,
        IDeclarationOf<IClassMethod>,
        IMemberOf<IInterface>
    {
    }
}
