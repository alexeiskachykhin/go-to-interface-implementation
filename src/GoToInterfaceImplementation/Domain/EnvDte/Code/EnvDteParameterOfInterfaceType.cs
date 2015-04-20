using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class EnvDteParameterOfInterfaceType : EnvDteParameter, IParameterOfInterfaceType
    {
        public IInterface Interface
        {
            get { return new EnvDteInterface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public EnvDteParameterOfInterfaceType(ICodeEditor codeEditor, CodeParameter codeParameter)
            : base(codeEditor, codeParameter)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IParameterOfInterfaceType, IClass> finder =
                new EnvDteParameterOfInterfaceTypeImplementationFinder();

            return finder.Find(this);
        }
    }
}
