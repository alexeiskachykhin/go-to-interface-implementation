using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class EnvDteInterfaceMethodImplementationFinder : IImplementationFinder<IInterfaceMethod, IClassMethod>
    {
        public IEnumerable<IClassMethod> Find(IInterfaceMethod codeInterfaceMethod)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceMethod.Interface.FindImplementations();
            IEnumerable<IClassMethod> methods = interfaceImplementations.SelectMany(i => i.Methods);
            IEnumerable<IClassMethod> matchedMethods = methods.Where(m => m.IsMatch(codeInterfaceMethod));

            return matchedMethods;
        }
    }
}
