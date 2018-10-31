using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Interfaces;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Events.SystemEvents;
using Eventos.IO.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Domain.Events.Commands
{
    public class EventCommandHandler : CommandHandler,
        IHandler<NewEventCommand>,
        IHandler<UpdateEventCommand>,
        IHandler<DeleteEventCommand>
    {

        private readonly IEventRepository _eventRepository;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IBus _bus;

        public EventCommandHandler(IEventRepository eventRepository, 
            IUnityOfWork unityOfWork,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> domainNotificationHandler) 
                : base(unityOfWork, bus, domainNotificationHandler)
        {
            _eventRepository = eventRepository;
            _unityOfWork = unityOfWork;
            _bus = bus;
        }

        public void Handle(NewEventCommand message)
        {
            var address = new Address(message.Address.Id, message.Address.Street, message.Address.Number, message.Address.Neibourhood, message.Address.PostalCode,
                message.Address.City, message.Address.State, message.Address.EventId);

            var ev = Event.EventFactory.NewEventFull(message.Id, message.Name, message.Desc, message.DescriptionFull, message.StartDate, message.FinalDate, 
                message.Free, message.Value, message.IsOnline, message.CompanyName, message.OrganizerId, address, message.CategoryId);

            if (!ev.IsValid())
            {
                NotifyErrorValidation(ev.ValidationResult);
                return;
            }

            // Todo: Business Validation
            // Organizador pode registrar um evento?

            // Persist on database
            _eventRepository.Add(ev);

            if (Commit())
            {
                Console.WriteLine("Event registred success.");
                _bus.RaiseEvent(new RegistredEventEvent(ev.Id, ev.Name, ev.StartDate, ev.FinalDate, ev.Free, ev.Value, ev.IsOnline, ev.CompanyName));
            }
        }

        public void Handle(UpdateEventCommand message)
        {
            var currentEvent = _eventRepository.GetById(message.Id);

            if (!ExistEvent(message.Id, message.MessageType))
            {
                return;
            }

            // Todo: Validar se o evento pertence a pessoa que esta editando

            var ev = Event.EventFactory.NewEventFull(message.Id, message.Name, message.Desc, message.DescriptionFull, message.StartDate, message.FinalDate,
                message.Free, message.Value, message.IsOnline, message.CompanyName, message.OrganizerId, currentEvent.Address, message.CategoryId);

            if (!EventIsValid(ev))
            {
                return;
            }

            _eventRepository.Update(ev);

            if (Commit())
            {
                _bus.RaiseEvent(new UpdatedEventEvent(ev.Id, ev.Name, ev.Desc, ev.DescriptionFull, ev.StartDate, ev.FinalDate, ev.Free, ev.Value, ev.IsOnline, ev.CompanyName));
            }
        }

        public void Handle(DeleteEventCommand message)
        {
            if (!ExistEvent(message.Id, message.MessageType))
            {
                return;
            }

            _eventRepository.Delete(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new DeletedEventEvent(message.Id));
            }
        }

        private bool EventIsValid(Event ev)
        {
            if (!ev.IsValid())
            {
                NotifyErrorValidation(ev.ValidationResult);
                return false;
            }

            return true;
        }

        private bool ExistEvent(Guid id, string messageType)
        {
            var ev = _eventRepository.GetById(id);

            if (ev != null)
            {
                return true;
            }

            _bus.RaiseEvent(new DomainNotification(messageType, "Event not found."));
            return false;
        }
    }
}
