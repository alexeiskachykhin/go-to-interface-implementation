using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IMemberOf<T>
        where T : IType
    {
        AccessModifier AccessModifier { get; }

        T ContainingType { get; }
    }
}
