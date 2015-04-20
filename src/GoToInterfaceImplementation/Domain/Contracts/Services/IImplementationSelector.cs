using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.Contracts.Services
{
    public interface IImplementationSelector
    {
        Task<ICodeElement> SelectAsync(IEnumerable<ICodeElement> codeElementImplementations);
    }
}
