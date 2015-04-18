using System;
using System.Collections.Generic;
using System.Linq;

using EnvDTE;

using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMember : IInterfaceMember
    {
        private readonly ICodeEditor _codeEditor;

        private readonly CodeFunction _codeFunction;


        public string FullName
        {
            get { return _codeFunction.FullName; }
        }

        public IInterface Interface
        {
            get { return new EnvDteInterface(_codeEditor, (CodeInterface)_codeFunction.Parent); }
        }

        public IEnumerable<IParameter> Parameters
        {
            get 
            {
                IEnumerable<IParameter> parameters =
                    from i in _codeFunction.Parameters.OfType<CodeParameter>()
                    select new EnvDteParameter(_codeEditor, i);

                return parameters;
            }
        }


        public EnvDteInterfaceMember(ICodeEditor codeEditor, CodeFunction codeFunction)
        {
            _codeEditor = codeEditor;
            _codeFunction = codeFunction;
        }


        public void RevealInCodeEditor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IClassMember> FindImplementations()
        {
            IImplementationFinder<IInterfaceMember, IClassMember> finder = 
                new EnvDteInterfaceMemberImplementationFinder();

            return finder.Find(this);
        }

        public bool IsMatch(IClassMember classMember)
        {
            IEnumerable<IParameter> classMemberParameters = classMember.Parameters;
            IEnumerable<IParameter> interfaceMemberParameters = this.Parameters;

            bool isMatch = classMemberParameters
                .Zip(interfaceMemberParameters, (p1, p2) => p1.FullName == p2.FullName)
                .All(p => p);

            return isMatch;
        }
    }
}
