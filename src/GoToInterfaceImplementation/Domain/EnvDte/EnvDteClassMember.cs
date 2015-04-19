using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClassMember : EnvDteCodeElement<CodeFunction>, IClassMember
    {
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


        public EnvDteClassMember(ICodeEditor codeEditor, CodeFunction codeFunction)
            : base(codeEditor, codeFunction)
        {
        }


        public bool IsMatch(IInterfaceMember declaration)
        {
            IEnumerable<IParameter> classMemberParameters = this.Parameters;
            IEnumerable<IParameter> interfaceMemberParameters = declaration.Parameters;

            bool isMatch = classMemberParameters
                .Zip(interfaceMemberParameters, (p1, p2) => p1.FullName == p2.FullName)
                .All(p => p);

            return isMatch;
        }
    }
}
