using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class ParameterOfInterfaceTypeImplementationFinder : IImplementationFinder<IParameterOfInterfaceType, IClass>
    {
        public IEnumerable<IClass> Find(IParameterOfInterfaceType interfaceParameter)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceParameter.Type.FindImplementations();

            return interfaceImplementations;
        }
    }
}
