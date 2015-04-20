using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterfaceMethodParameter : IParameter, IDeclarationOf<IClass>
    {
        IInterface Interface { get; }
    }
}
