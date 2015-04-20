using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterface : ICodeElement, IDeclarationOf<IClass>
    {
    }
}
