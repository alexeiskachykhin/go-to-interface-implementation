using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    public class EnvDteInterfacePropertyImplementationFinder : IImplementationFinder<IInterfaceProperty, IClassProperty>
    {
        public IEnumerable<IClassProperty> Find(IInterfaceProperty codeInterfaceProperty)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceProperty.Interface.FindImplementations();
            IEnumerable<IClassProperty> properties = interfaceImplementations.SelectMany(i => i.Properties);
            IEnumerable<IClassProperty> matchedProperties = properties.Where(m => m.IsMatch(codeInterfaceProperty));

            return matchedProperties;
        }
    }
}
