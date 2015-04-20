using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts.Code;
using GoToInterfaceImplementation.Domain.Contracts.Editor;
using GoToInterfaceImplementation.Domain.Contracts.Services;
using GoToInterfaceImplementation.Domain.EnvDte.Services;

namespace GoToInterfaceImplementation.Domain.EnvDte.Code
{
    public class EnvDteInterfaceMethod : EnvDteCodeElement<CodeFunction>, IInterfaceMethod
    {
        public IInterface Interface
        {
            get { return new EnvDteInterface(CodeEditor, (CodeInterface)CodeElement.Parent); }
        }

        public string ReturnTypeFullName
        {
            get { return CodeElement.Type.AsFullName; }
        }

        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in CodeElement.Parameters.OfType<CodeParameter>()
                    select new EnvDteParameter(CodeEditor, i);

                return parameters;
            }
        }


        public EnvDteInterfaceMethod(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public IEnumerable<IClassMethod> FindImplementations()
        {
            IImplementationFinder<IInterfaceMethod, IClassMethod> finder = 
                new EnvDteInterfaceMethodImplementationFinder();

            return finder.Find(this);
        }
    }
}
