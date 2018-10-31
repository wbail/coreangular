using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.SystemEvents
{
    public class DeletedEventEvent : BaseEventEvent
    {
        public DeletedEventEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
