using System;
using System.Collections.Generic;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMethodParameter : EnvDteParameter, IInterfaceMethodParameter
    {
        public IInterface Interface
        {
            get { return new EnvDteInterface(CodeEditor, (CodeInterface)CodeElement.Type.CodeType); }
        }


        public EnvDteInterfaceMethodParameter(ICodeEditor codeEditor, CodeParameter codeParameter)
            : base(codeEditor, codeParameter)
        {
        }


        public IEnumerable<IClass> FindImplementations()
        {
            IImplementationFinder<IInterfaceMethodParameter, IClass> finder =
                new EnvDteInterfaceMethodParameterImplementationFinder();

            return finder.Find(this);
        }
    }
}
