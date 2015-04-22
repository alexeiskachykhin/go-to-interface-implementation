using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IDefinitionOf<in T>
        where T : ISemanticElement
    {
        bool IsMatch(T declaration);
    }
}
