using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMember : EnvDteCodeElement<CodeFunction>, IInterfaceMember
    {
        public IInterface Interface
        {
            get { return new EnvDteInterface(CodeEditor, (CodeInterface)CodeElement.Parent); }
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


        public EnvDteInterfaceMember(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public IEnumerable<IClassMember> FindImplementations()
        {
            IImplementationFinder<IInterfaceMember, IClassMember> finder = 
                new EnvDteInterfaceMemberImplementationFinder();

            return finder.Find(this);
        }
    }
}
