using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IField : ISemanticElement
    {
        string TypeFullName { get; }
    }
}
