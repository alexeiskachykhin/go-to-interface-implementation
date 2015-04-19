﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassEvent : EnvDteCodeElement<CodeEvent>, IClassEvent
    {
        public EnvDteClassEvent(ICodeEditor codeEditor, CodeEvent codeEvent)
            : base(codeEditor, codeEvent)
        {
        }


        public bool IsMatch(IInterfaceEvent declaration)
        {
            ISignature classEventSignature = new Signature()
            {
                Name = Name
            };

            ISignature interfaceEventSignature = new Signature()
            {
                Name = declaration.Name
            };

            return classEventSignature.Equals(interfaceEventSignature);
        }
    }
}