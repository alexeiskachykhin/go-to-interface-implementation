using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClassMember : ICodeElement
    {
        IEnumerable<IParameter> Parameters { get; }
    }
}
