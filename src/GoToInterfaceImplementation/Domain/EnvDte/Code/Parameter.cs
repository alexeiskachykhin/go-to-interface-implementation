﻿using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class Parameter : SemanticElement<CodeParameter>, IParameter
    {
        public string TypeFullName
        {
            get { return CodeElement.Type.AsFullName; }
        }


        public Parameter(ICodeEditor codeEditor, CodeParameter codeParameter)
            : base(codeEditor, codeParameter)
        {
        }
    }
}
