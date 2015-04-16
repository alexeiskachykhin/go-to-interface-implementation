using System;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteFactory : Factory
    {
        public override T Create<T>()
        {
            if (typeof(T) == typeof(ICodeEditor))
            {
                return new EnvDteCodeEditor() as T;
            }

            throw new InvalidOperationException("Object of type " + typeof(T).FullName + ". Can't be constructed with this factory.");
        }
    }
}
