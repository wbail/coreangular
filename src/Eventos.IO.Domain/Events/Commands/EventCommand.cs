using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.Commands
{
    public abstract class EventCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Desc { get; protected set; }

        public string DescriptionFull { get; protected set; }

        public DateTime StartDate { get; protected set; }

        public DateTime FinalDate { get; protected set; }

        public bool Free { get; protected set; }

        public decimal Value { get; protected set; }

        public bool IsOnline { get; protected set; }

        public string CompanyName { get; protected set; }

        public Guid OrganizerId { get; protected set; }

        public Address Address { get; protected set; }

        public Category Category { get; protected set; }

        public Guid CategoryId { get; protected set; }
    }
}
