using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class FieldOfInterfaceType : Field, IFieldOfInterfaceType
    {
        public IInterface Interface
        {
            get { return new Interface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public FieldOfInterfaceType(ICodeEditor codeEditor, CodeVariable2 codeVariable)
            : base(codeEditor, codeVariable)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            throw new NotImplementedException();
        }
    }
}
