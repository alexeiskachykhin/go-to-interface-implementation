using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IParameter : ICodeElement
    {
        string TypeFullName { get; }
    }
}
