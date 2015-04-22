using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IExecutableSemanticElement : ISemanticElement
    {
        string ReturnTypeFullName { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
