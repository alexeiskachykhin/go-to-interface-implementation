using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceMemberImplementationFinder : IImplementationFinder<IInterfaceMember, IClassMember>
    {
        public IEnumerable<IClassMember> Find(IInterfaceMember codeInterfaceMember)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceMember.Interface.FindImplementations();
            IEnumerable<IClassMember> members = interfaceImplementations.SelectMany(i => i.Members);
            IEnumerable<IClassMember> matchedMembers = members.Where(m => m.IsMatch(codeInterfaceMember));

            return matchedMembers;
        }
    }
}
