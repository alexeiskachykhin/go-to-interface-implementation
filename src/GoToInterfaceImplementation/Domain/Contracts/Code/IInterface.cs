﻿using System;
using System.Collections.Generic;

namespace GoToInterfaceImplementation.Domain.Contracts.Code
{
    public interface IInterface : IType, IDeclarationOf<IClass>
    {
    }
}
