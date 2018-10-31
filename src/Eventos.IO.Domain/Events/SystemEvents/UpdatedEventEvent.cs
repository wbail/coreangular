using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.SystemEvents
{
    public class UpdatedEventEvent : BaseEventEvent
    {
        public UpdatedEventEvent(Guid id, string name, string desc, string descriptionFull, DateTime startDate, DateTime finalDate,
            bool free, decimal value, bool isOnline, string companyName)
        {
            Id = id;
            Name = name;
            Desc = desc;
            DescriptionFull = descriptionFull;
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
