using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class EnvDteParameterOfInterfaceTypeImplementationFinder : IImplementationFinder<IParameterOfInterfaceType, IClass>
    {
        public IEnumerable<IClass> Find(IParameterOfInterfaceType codeParameter)
        {
            IEnumerable<IClass> interfaceImplementations = codeParameter.Interface.FindImplementations();

            return interfaceImplementations;
        }
    }
}
