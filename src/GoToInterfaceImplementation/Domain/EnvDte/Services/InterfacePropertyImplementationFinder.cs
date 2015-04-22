using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class InterfacePropertyImplementationFinder : IImplementationFinder<IInterfaceProperty, IClassProperty>
    {
        public IEnumerable<IClassProperty> Find(IInterfaceProperty interfaceProperty)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceProperty.Interface.FindImplementations();
            IEnumerable<IClassProperty> properties = interfaceImplementations.SelectMany(i => i.Properties);
            IEnumerable<IClassProperty> matchedProperties = properties.Where(m => m.IsMatch(interfaceProperty));

            return matchedProperties;
        }
    }
}
