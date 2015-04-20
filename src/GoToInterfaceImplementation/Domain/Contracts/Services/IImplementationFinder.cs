using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.Contracts.Services
{
    public interface IImplementationFinder<TDeclaration, TDefinition>
        where TDeclaration : IDeclarationOf<TDefinition>
        where TDefinition : ICodeElement
    {
        IEnumerable<TDefinition> Find(TDeclaration codeElement);
    }
}
