using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMethodImplementationFinder : IImplementationFinder<IInterfaceMethod, IClassMethod>
    {
        public IEnumerable<IClassMethod> Find(IInterfaceMethod codeInterfaceFunction)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceFunction.Interface.FindImplementations();
            IEnumerable<IClassMethod> methods = interfaceImplementations.SelectMany(i => i.Methods);
            IEnumerable<IClassMethod> matchedMethods = methods.Where(m => m.IsMatch(codeInterfaceFunction));

            return matchedMethods;
        }
    }
}
