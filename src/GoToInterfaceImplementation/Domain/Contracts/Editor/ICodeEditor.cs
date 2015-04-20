using System;
using System.Collections.Generic;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.Contracts.Editor
{
    public interface ICodeEditor
    {
        ICodeElement GetSelectedCodeElement();

        IEnumerable<IClass> GetClassesInSolution();
    }
}
