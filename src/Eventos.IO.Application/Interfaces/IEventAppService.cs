using Eventos.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.IO.Application.Interfaces
{
    public interface IEventAppService : IDisposable
    {
        void New(EventViewModel eventViewModel);

        IEnumerable<EventViewModel> GetAll();

        EventViewModel GetById(Guid id);

        IEnumerable<EventViewModel> GetEventByOrganizer(Guid organizerId);

        void Update(EventViewModel eventViewModel);

        void Delete(Guid id);
    }
}
