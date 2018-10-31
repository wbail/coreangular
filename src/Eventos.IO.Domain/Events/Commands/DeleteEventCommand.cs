using System;

namespace Eventos.IO.Domain.Events.Commands
{
    public class DeleteEventCommand : EventCommand
    {
        public DeleteEventCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
