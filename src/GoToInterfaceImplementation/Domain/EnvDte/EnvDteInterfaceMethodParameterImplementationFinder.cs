using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMethodParameterImplementationFinder : IImplementationFinder<IInterfaceMethodParameter, IClass>
    {
        public IEnumerable<IClass> Find(IInterfaceMethodParameter codeInterfaceMethodParameter)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceMethodParameter.Interface.FindImplementations();

            return interfaceImplementations;
        }
    }
}
