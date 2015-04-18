using System;

using GoToInterfaceImplementation.Domain.EnvDte;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain
{
    public abstract class Factory
    {
        public abstract ICodeEditor CreateCodeEditor();

        public abstract IInterfaceImplementationFinder CreateInterfaceImplementationFinder(ICodeEditor codeEditor);

        public abstract IInterfaceImplementationPresenter CreateInterfaceImplementationPresenter(ICodeEditor codeEditor);


        private static Factory _current;


        public static Factory Current
        {
            get 
            {
                if (_current == null)
                {
                    _current = new EnvDteFactory();
                }

                return _current;
            }
        }
    }
}
