using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IDeclarationOf<out T>
        where T : ICodeElement
    {
        IEnumerable<T> FindImplementations();
    }
}
