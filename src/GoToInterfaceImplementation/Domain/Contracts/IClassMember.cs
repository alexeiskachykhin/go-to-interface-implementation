using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClassMember : ICodeElement, IDefinitionOf<IInterfaceMember>
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
