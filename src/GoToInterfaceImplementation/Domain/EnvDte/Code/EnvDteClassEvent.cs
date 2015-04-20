﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class EnvDteClassEvent : EnvDteCodeElement<CodeEvent>, IClassEvent
    {
        public EnvDteClassEvent(ICodeEditor codeEditor, CodeEvent codeEvent)
            : base(codeEditor, codeEvent)
        {
        }


        public bool IsMatch(IInterfaceEvent declaration)
        {
            Signature classEventSignature = new Signature()
            {
                Name = Name
            };

            Signature interfaceEventSignature = new Signature()
            {
                Name = declaration.Name
            };

            return classEventSignature.Equals(interfaceEventSignature);
        }
    }
}