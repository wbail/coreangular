using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.Events.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.Services
{
    public class EventAppService : IEventAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;

        public EventAppService(IBus bus, IMapper mapper, IEventRepository eventRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public void Delete(Guid id)
        {
            var deleteCommand = _mapper.Map<DeleteEventCommand>(id);
            _bus.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            _eventRepository.Dispose();
        }

        public IEnumerable<EventViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<EventViewModel>>(_eventRepository.GetAll());
        }

        public EventViewModel GetById(Guid id)
        {
            return _mapper.Map<EventViewModel>(_eventRepository.GetById(id));
        }

        public IEnumerable<EventViewModel> GetEventByOrganizer(Guid organizerId)
        {
            return _mapper.Map<IEnumerable<EventViewModel>>(_eventRepository.GetAddressByOrganizer(organizerId));
        }

        public void New(EventViewModel eventViewModel)
        {
            var newCommand = _mapper.Map<NewEventCommand>(eventViewModel);
            _bus.SendCommand(newCommand);
        }

        public void Update(EventViewModel eventViewModel)
        {
            // Todo: Validade if organizer is owner of the event

            var updateCommand = _mapper.Map<UpdateEventCommand>(eventViewModel);
            _bus.SendCommand(updateCommand);
        }
    }
}
