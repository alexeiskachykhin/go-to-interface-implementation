using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteParameterOfInterfaceTypeImplementationFinder : IImplementationFinder<IParameterOfInterfaceType, IClass>
    {
        public IEnumerable<IClass> Find(IParameterOfInterfaceType codeParameter)
        {
            IEnumerable<IClass> interfaceImplementations = codeParameter.Interface.FindImplementations();

            return interfaceImplementations;
        }
    }
}
