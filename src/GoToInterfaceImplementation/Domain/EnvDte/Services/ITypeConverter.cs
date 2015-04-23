using System;
using System.Collections.Generic;
using System.Linq;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal interface ITypeConverter<TSource, TDestination>
    {
        TDestination Convert(TSource source);
    }
}
