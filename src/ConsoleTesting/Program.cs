using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Interfaces;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Events;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Events.SystemEvents;
using Eventos.IO.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bus = new FakeBus();

            //// New event with success
            //var cmd = new NewEventCommand("DevX", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), false, 1000, false, "ExxonMobil");
            //Start(cmd);
            //bus.SendCommand(cmd);
            //End(cmd);

            //// New event with errors
            //cmd = new NewEventCommand("", DateTime.Now.AddDays(2), DateTime.Now.AddDays(1), false, 0, false, "");
            //Start(cmd);
            //bus.SendCommand(cmd);
            //End(cmd);

            //// Update event
            //var cmd2 = new UpdateEventCommand(Guid.NewGuid(), "DevX", "", "", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), true, 0, true, "ExxonMobil");
            //Start(cmd2);
            //bus.SendCommand(cmd2);
            //End(cmd2);

            //// Delete event
            //var cmd3 = new DeleteEventCommand(Guid.NewGuid());
            //Start(cmd3);
            //bus.SendCommand(cmd3);
            //End(cmd3);

            //Console.ReadKey();
        }

        private static void Start(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Initiating command " + message.MessageType);
        }

        private static void End(Message message)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("End of Command " + message.MessageType);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****************");
            Console.WriteLine("");
        }
    }

    public class FakeBus : IBus
    {
        public void RaiseEvent<T>(T theEvent) where T : Eventos.IO.Domain.Core.Events.Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Command { theCommand.MessageType } was started.");
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            var msgType = message.MessageType;

            if (msgType.Equals("DomainNotification"))
            {
                var obj = new DomainNotificationHandler();
                ((IDomainNotificationHandler<T>)obj).Handle(message);
            }

            if (msgType.Equals("NewEventCommand") ||
                msgType.Equals("UpdateEventCommand") ||
                msgType.Equals("DeleteEventCommand"))
            {
                var obj = new EventCommandHandler(new FakEventRepository(), new FakeUow(), new FakeBus(), new DomainNotificationHandler());
                ((IHandler<T>)obj).Handle(message);
            }

            if (msgType.Equals("RegistredEventEvent") ||
                msgType.Equals("UpdatedEventEvent") ||
                msgType.Equals("DeletedEventEvent"))
            {
                var obj = new EventHandlerEvent();
                ((IHandler<T>)obj).Handle(message);
            }


        }
    }

    public class FakEventRepository : IEventRepository
    {
        public void Add(Eventos.IO.Domain.Events.Event obj)
        {
            //
        }

        public void AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            //
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eventos.IO.Domain.Events.Event> Find(Expression<Func<Eventos.IO.Domain.Events.Event, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Address GetAddressById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eventos.IO.Domain.Events.Event> GetAddressByOrganizer(Guid organizerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eventos.IO.Domain.Events.Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Eventos.IO.Domain.Events.Event GetById(Guid id)
        {
            return new Eventos.IO.Domain.Events.Event("Fake", DateTime.Now, DateTime.Now, false, 10000, false, "GB Engenharia");
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Eventos.IO.Domain.Events.Event obj)
        {
            //
        }

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeUow : IUnityOfWork
    {
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
