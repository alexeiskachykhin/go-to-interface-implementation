using System;

using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteFactory : Factory
    {
        public override ICodeEditor CreateCodeEditor()
        {
            return new EnvDteCodeEditor();
        }

        public override IImplementationPresenter CreateImplementationPresenter()
        {
            return new EnvDteImplementationPresenter();
        }
    }
}
