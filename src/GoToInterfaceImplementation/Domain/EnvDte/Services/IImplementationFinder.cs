using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal interface IImplementationFinder<TDeclaration, TDefinition>
        where TDeclaration : IDeclarationOf<TDefinition>
        where TDefinition : ISemanticElement
    {
        IEnumerable<TDefinition> Find(TDeclaration semanticElement);
    }
}
