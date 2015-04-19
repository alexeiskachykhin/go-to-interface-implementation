using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IClass : ICodeElement, IDefinitionOf<IInterface>
    {
        IEnumerable<IInterface> ImplementedInterfaces { get; }

        IEnumerable<IClassMethod> Methods { get; }

        IEnumerable<IClassProperty> Properties { get; }

        IEnumerable<IClassEvent> Events { get; }
    }
}
