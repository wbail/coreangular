using Eventos.IO.Domain.Repository;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Events.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        IEnumerable<Event> GetAddressByOrganizer(Guid organizerId);

        Address GetAddressById(Guid id);

        void AddAddress(Address address);

        void UpdateAddress(Address address);
    }
}
