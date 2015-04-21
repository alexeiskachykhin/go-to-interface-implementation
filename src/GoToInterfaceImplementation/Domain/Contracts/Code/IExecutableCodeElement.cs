using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IExecutableCodeElement : ICodeElement
    {
        string ReturnTypeFullName { get; }

        IEnumerable<IParameter> Parameters { get; }
    }
}
