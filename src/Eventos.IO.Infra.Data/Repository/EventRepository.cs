using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventos.IO.Infra.Data.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(EventsContext context) : base(context)
        {

        }

        public void AddAddress(Address address)
        {
            Db.Addresses.Add(address);
        }

        public Address GetAddressById(Guid id)
        {
            return Db.Addresses
                .Find(id);
        }

        public IEnumerable<Event> GetAddressByOrganizer(Guid organizerId)
        {
            return Db.Events
                .Where(e => e.OrganizerId == organizerId);
        }

        public override Event GetById(Guid id)
        {
            return Db.Events
                .Include(e => e.Address)
                .FirstOrDefault(e => e.Id == id);
        }

        public void UpdateAddress(Address address)
        {
            Db.Addresses.Update(address);
        }
    }
}
