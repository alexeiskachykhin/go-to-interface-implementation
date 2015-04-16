using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoToInterfaceImplementation.Integration
{
    public class PackageServiceLocator
    {
        private readonly Func<Type, object> _serviceLocator;


        public PackageServiceLocator(Func<Type, object> serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }


        public T GetService<T>() 
            where T : class
        {
            return GetService<T, T>();
        }

        public TConcreteType GetService<TInterfaceType, TConcreteType>()
            where TConcreteType : class
        {
            return _serviceLocator(typeof(TInterfaceType)) as TConcreteType;
        }


        public static PackageServiceLocator Current { get; set; }
    }
}
