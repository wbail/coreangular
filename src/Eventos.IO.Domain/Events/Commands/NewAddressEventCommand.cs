using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.Commands
{
    public class NewAddressEventCommand : Command
    {
        public NewAddressEventCommand(Guid id, string street, string number, string neibourhood, string postalCode, string city, string state, Guid? eventId)
        {
            Id = id;
            Street = street;
            Number = number;
            Neibourhood = neibourhood;
            PostalCode = postalCode;
            City = city;
            State = state;
            EventId = eventId;
        }

        public Guid Id { get; private set; }

        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Neibourhood { get; private set; }

        public string PostalCode { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public Guid? EventId { get; private set; }
    }
}
