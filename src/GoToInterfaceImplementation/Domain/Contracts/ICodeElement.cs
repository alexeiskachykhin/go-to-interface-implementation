using System;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface ICodeElement
    {
        string FullName { get; }


        void RevealInCodeEditor();
    }
}
