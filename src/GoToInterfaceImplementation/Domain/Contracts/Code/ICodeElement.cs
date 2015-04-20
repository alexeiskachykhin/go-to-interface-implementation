using System;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface ICodeElement
    {
        string Name { get; }

        string FullName { get; }


        void RevealInCodeEditor();
    }
}
