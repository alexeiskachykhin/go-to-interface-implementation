using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class Field : SemanticElement<CodeVariable2>, IField
    {
        public string TypeFullName
        {
            get { return CodeElement.Type.AsFullName; }
        }


        public Field(ICodeEditor codeEditor, CodeVariable2 codeVariable)
            : base(codeEditor, codeVariable)
        {
        }
    }
}
