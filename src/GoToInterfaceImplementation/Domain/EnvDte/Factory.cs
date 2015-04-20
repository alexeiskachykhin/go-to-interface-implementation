using System;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class Factory : AbstractFactory
    {
        public override ICodeEditor CreateCodeEditor()
        {
            return new CodeEditor();
        }

        public override IImplementationSelector CreateImplementationSelector()
        {
            return new ImplementationSelector();
        }
    }
}
