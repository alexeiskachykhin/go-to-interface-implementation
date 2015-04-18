using System;

using GoToInterfaceImplementation.Domain.Contracts;

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
