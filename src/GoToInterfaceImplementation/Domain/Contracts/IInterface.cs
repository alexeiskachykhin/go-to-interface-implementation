using System;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface IInterface : ICodeElement
    {
        void RevealImplementationInCodeWindow();
    }
}
