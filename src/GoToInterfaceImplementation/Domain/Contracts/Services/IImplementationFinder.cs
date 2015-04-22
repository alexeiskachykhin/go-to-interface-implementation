using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.Contracts.Services
{
    public interface IImplementationFinder<TDeclaration, TDefinition>
        where TDeclaration : IDeclarationOf<TDefinition>
        where TDefinition : ISemanticElement
    {
        IEnumerable<TDefinition> Find(TDeclaration semanticElement);
    }
}
