using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain
{
    public class ImplementationSelector : IImplementationSelector
    {
        public Task<ICodeElement> SelectAsync(IEnumerable<ICodeElement> codeElementImplementations)
        {
            ICodeElement firstImplementation = codeElementImplementations.FirstOrDefault();

            return Task.FromResult(firstImplementation);
        }
    }
}
