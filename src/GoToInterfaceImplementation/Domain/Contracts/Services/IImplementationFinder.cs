using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IImplementationFinder<TDeclaration, TDefinition>
        where TDeclaration : IDeclarationOf<TDefinition>
        where TDefinition : ICodeElement
    {
        IEnumerable<TDefinition> Find(TDeclaration codeElement);
    }
}
