using System;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IAlgorithm
    {
        Task ExecuteAsync();
    }
}
