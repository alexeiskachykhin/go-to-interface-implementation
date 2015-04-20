using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IParameterOfInterfaceType : IParameter, IDeclarationOf<IClass>
    {
        IInterface Interface { get; }
    }
}
