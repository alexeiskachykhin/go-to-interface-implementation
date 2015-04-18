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

        public override IInterfaceImplementationFinder CreateInterfaceImplementationFinder(ICodeEditor codeEditor)
        {
            return new EnvDteInterfaceImplementationFinder(codeEditor);
        }

        public override IInterfaceImplementationPresenter CreateInterfaceImplementationPresenter(ICodeEditor codeEditor)
        {
            return new EnvDteInterfaceImplementationPresenter(codeEditor);
        }
    }
}
