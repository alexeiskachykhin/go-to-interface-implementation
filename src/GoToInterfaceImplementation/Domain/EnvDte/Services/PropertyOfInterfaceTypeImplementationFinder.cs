using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class PropertyOfInterfaceTypeImplementationFinder : IImplementationFinder<IPropertyOfInterfaceType, IClass>
    {
        public IEnumerable<IClass> Find(IPropertyOfInterfaceType interfaceProperty)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceProperty.ReturnType.FindImplementations();

            return interfaceImplementations;
        }
    }
}
