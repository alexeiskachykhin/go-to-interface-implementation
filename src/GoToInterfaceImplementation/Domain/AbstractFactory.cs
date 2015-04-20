using System;

using GoToInterfaceImplementation.Domain.EnvDte;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;

namespace GoToInterfaceImplementation.Domain
{
    public abstract class AbstractFactory
    {
        public abstract ICodeEditor CreateCodeEditor();

        public abstract IImplementationSelector CreateImplementationSelector();


        private static AbstractFactory _current;


        public static AbstractFactory Current
        {
            get 
            {
                if (_current == null)
                {
                    _current = new Factory();
                }

                return _current;
            }
        }
    }
}
