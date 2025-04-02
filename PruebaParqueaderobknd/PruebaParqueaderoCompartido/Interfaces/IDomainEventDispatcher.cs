using PruebaParqueaderoCompartido.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaParqueaderoCompartido.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IEnumerable<DomainEventBase> events);
    }
}
