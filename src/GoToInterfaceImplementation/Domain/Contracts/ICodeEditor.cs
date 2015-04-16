using System;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface ICodeEditor
    {
        ICodeElement GetSelectedCodeElement();
    }
}
