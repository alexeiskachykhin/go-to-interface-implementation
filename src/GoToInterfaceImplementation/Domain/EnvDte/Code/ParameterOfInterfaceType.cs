using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class ParameterOfInterfaceType : Parameter, IParameterOfInterfaceType
    {
        public IInterface Interface
        {
            get { return new Interface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public ParameterOfInterfaceType(ICodeEditor codeEditor, CodeParameter codeParameter)
            : base(codeEditor, codeParameter)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IParameterOfInterfaceType, IClass> finder =
                new ParameterOfInterfaceTypeImplementationFinder();

            return finder.Find(this);
        }
    }
}
