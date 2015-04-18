using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IImplementationFinder<TDeclaration, TDefinition>
    {
        IEnumerable<TDefinition> Find(TDeclaration codeElement);
    }
}
