using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterface : ICodeElement, IDeclarationOf<IClass>
    {
    }
}
