using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.SystemEvents
{
    public class RegistredEventEvent : BaseEventEvent
    {
        public RegistredEventEvent(Guid id, string name, DateTime startDate, DateTime finalDate,
            bool free, decimal value, bool isOnline, string companyName)
        {
            Name = name;
            StartDate = startDate;
            FinalDate = finalDate;
            Free = free;
            Value = value;
            IsOnline = isOnline;
            CompanyName = companyName;

            AggregateId = id;
        }
    }
}
