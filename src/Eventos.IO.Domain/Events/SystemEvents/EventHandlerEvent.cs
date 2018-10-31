using Eventos.IO.Domain.Core.Interfaces;
using Eventos.IO.Domain.Events.SystemEvents;
using System;

namespace Eventos.IO.Domain.Events.SystemEvents
{
    public class EventHandlerEvent :
        IHandler<RegistredEventEvent>,
        IHandler<UpdatedEventEvent>,
        IHandler<DeletedEventEvent>
    {
        public void Handle(RegistredEventEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Event registered with success.");
        }

        public void Handle(UpdatedEventEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Event updated with success.");
        }

        public void Handle(DeletedEventEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Event deleted with success.");
        }
    }
}
