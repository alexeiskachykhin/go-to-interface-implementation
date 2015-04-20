using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Integration;
using GoToInterfaceImplementation.Domain.Contracts;

namespace GoToInterfaceImplementation.Domain.EnvDte
{
    public class EnvDteInterfaceEventImplementationFinder : IImplementationFinder<IInterfaceEvent, IClassEvent>
    {
        public IEnumerable<IClassEvent> Find(IInterfaceEvent codeInterfaceEvent)
        {
            IEnumerable<IClass> interfaceImplementations = codeInterfaceEvent.Interface.FindImplementations();
            IEnumerable<IClassEvent> events = interfaceImplementations.SelectMany(i => i.Events);
            IEnumerable<IClassEvent> matchedEvents = events.Where(m => m.IsMatch(codeInterfaceEvent));

            return matchedEvents;
        }
    }
}
