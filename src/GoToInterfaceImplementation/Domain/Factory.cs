using System;

using GoToInterfaceImplementation.Domain.EnvDte;

namespace GoToInterfaceImplementation.Domain
{
    public abstract class Factory
    {
        public abstract T Create<T>()
            where T : class;


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
