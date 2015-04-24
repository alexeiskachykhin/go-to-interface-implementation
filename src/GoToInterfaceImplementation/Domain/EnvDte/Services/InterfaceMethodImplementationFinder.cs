using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class InterfaceMethodImplementationFinder : IImplementationFinder<IInterfaceMethod, IClassMethod>
    {
        public IEnumerable<IClassMethod> Find(IInterfaceMethod interfaceMethod)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceMethod.ContainingType.FindImplementations();
            IEnumerable<IClassMethod> methods = interfaceImplementations.SelectMany(i => i.Methods);
            IEnumerable<IClassMethod> matchedMethods = methods.Where(m => m.IsMatch(interfaceMethod));

            return matchedMethods;
        }
    }
}
