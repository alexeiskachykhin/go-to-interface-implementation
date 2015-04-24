using System;
using System.Collections.Generic;
using System.Linq;

using GoToInterfaceImplementation.Domain.Contracts.Code;

namespace GoToInterfaceImplementation.Domain.EnvDte.Services
{
    internal class InterfaceEventImplementationFinder : IImplementationFinder<IInterfaceEvent, IClassEvent>
    {
        public IEnumerable<IClassEvent> Find(IInterfaceEvent interfaceEvent)
        {
            IEnumerable<IClass> interfaceImplementations = interfaceEvent.ContainingType.FindImplementations();
            IEnumerable<IClassEvent> events = interfaceImplementations.SelectMany(i => i.Events);
            IEnumerable<IClassEvent> matchedEvents = events.Where(m => m.IsMatch(interfaceEvent));

            return matchedEvents;
        }
    }
}
