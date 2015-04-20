using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IParameter : ICodeElement
    {
        string FullTypeName { get; }
    }
}
