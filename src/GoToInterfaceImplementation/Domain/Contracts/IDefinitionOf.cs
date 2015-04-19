using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IDefinitionOf<in T>
        where T : ICodeElement
    {
        bool IsMatch(T declaration);
    }
}
