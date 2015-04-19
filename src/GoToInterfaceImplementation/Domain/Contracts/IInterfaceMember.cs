using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceMember : ICodeElement, IDeclarationOf<IClassMember>
    {
        IInterface Interface { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
