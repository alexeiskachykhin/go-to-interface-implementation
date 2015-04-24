using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IPropertyOfInterfaceType : IProperty, IDeclarationOf<IClass>
    {
        IInterface ReturnType { get; }
    }
}
