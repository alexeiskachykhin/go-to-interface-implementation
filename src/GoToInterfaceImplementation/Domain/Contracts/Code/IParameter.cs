using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IParameter : ISemanticElement
    {
        string TypeFullName { get; }
    }
}
