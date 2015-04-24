using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;
using EnvDTE80;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class FieldOfInterfaceType : Field, IFieldOfInterfaceType
    {
        public IInterface Type
        {
            get { return new Interface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public FieldOfInterfaceType(ICodeEditor codeEditor, CodeVariable2 codeVariable)
            : base(codeEditor, codeVariable)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IFieldOfInterfaceType, IClass> finder = 
                new FieldOfInterfaceTypeImplementationFinder();

            return finder.Find(this);
        }
    }
}
