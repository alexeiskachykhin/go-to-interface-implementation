using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class VsCMAccessToAccessModifierConverter
        : ITypeConverter<vsCMAccess, AccessModifier>
    {
        public AccessModifier Convert(vsCMAccess source)
        {
            switch (source)
            {
                case vsCMAccess.vsCMAccessPublic:
                    return AccessModifier.Public;

                case vsCMAccess.vsCMAccessPrivate:
                    return AccessModifier.Private;

                case vsCMAccess.vsCMAccessProtected:
                    return AccessModifier.Protected;

                case vsCMAccess.vsCMAccessAssemblyOrFamily:
                    return AccessModifier.ProtectedInternal;

                default:
                    throw new ArgumentOutOfRangeException("source");
            }
        }
    }
}
