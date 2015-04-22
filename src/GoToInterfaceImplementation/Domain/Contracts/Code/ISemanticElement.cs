using System;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface ISemanticElement
    {
        string Name { get; }

        string FullName { get; }


        void RevealInCodeEditor();
    }
}
