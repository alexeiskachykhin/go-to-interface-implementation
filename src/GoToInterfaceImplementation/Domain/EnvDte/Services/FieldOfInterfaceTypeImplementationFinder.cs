using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class FieldOfInterfaceTypeImplementationFinder : IImplementationFinder<IFieldOfInterfaceType, IClass>
    {
        public IEnumerable<IClass> Find(IFieldOfInterfaceType interfaceField)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceField.Type.FindImplementations();

            return interfaceImplementations;
        }
    }
}
