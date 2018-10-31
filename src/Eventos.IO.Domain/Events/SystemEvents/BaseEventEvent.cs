using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.SystemEvents
{
    public abstract class BaseEventEvent : Eventos.IO.Domain.Core.Events.Event
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
    }
}
