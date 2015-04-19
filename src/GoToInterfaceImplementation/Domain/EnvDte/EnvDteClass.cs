using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteClass : EnvDteCodeElement<CodeClass>, IClass
    {
        public IEnumerable<IClassMember> Members
        {
            get 
            {
                IEnumerable<IClassMember> classMembers =
                    from i in CodeElement.Children.OfType<CodeFunction>()
                    select new EnvDteClassMember(CodeEditor, i);

                return classMembers;
            }
        }

        public IEnumerable<IInterface> ImplementedInterfaces
        {
            get 
            {
                IEnumerable<IInterface> implementedInterfaces =
                    from i in CodeElement.ImplementedInterfaces.OfType<CodeInterface>()
                    select new EnvDteInterface(CodeEditor, i);

                return implementedInterfaces;
            }
        }


        public EnvDteClass(ICodeEditor codeEditor, CodeClass codeElement)
            : base(codeEditor, codeElement)
        {
        }


        public bool IsMatch(IInterface declaration)
        {
            bool isMatch = this.ImplementedInterfaces.Any(
                c => declaration.FullName == c.FullName);

            return isMatch;
        }
    }
}
