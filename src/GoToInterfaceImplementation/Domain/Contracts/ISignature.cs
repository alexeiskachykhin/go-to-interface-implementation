using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface ISignature : IEquatable<ISignature>
    {
        string FullName { get; set; }

        string Name { get; set; }

        IEnumerable<IParameter> Parameters { get; set; }
    }
}
