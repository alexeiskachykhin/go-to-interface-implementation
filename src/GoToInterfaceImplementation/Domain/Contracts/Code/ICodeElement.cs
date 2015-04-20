using System;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface ICodeElement
    {
        string Name { get; }

        string FullName { get; }


        void RevealInCodeEditor();
    }
}
