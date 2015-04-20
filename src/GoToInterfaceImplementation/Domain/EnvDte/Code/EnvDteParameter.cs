using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class EnvDteParameter : EnvDteCodeElement<CodeParameter>, IParameter
    {
        public string FullTypeName
        {
            get { return CodeElement.Type.AsFullName; }
        }


        public EnvDteParameter(ICodeEditor codeEditor, CodeParameter codeParameter)
            : base(codeEditor, codeParameter)
        {
        }
    }
}
