using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts
{
    public interface ICodeEditor
    {
        ICodeElement GetSelectedCodeElement();

        IEnumerable<IClass> GetClassesInSolution();
    }
}
