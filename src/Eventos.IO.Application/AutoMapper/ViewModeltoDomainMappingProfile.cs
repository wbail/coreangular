using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Events.Commands;
using System;

namespace Eventos.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventViewModel, NewEventCommand>()
                .ConstructUsing(c => new NewEventCommand(c.Name, c.Desc, c.DescriptionFull, c.StartDate, c.FinalDate, c.Free, c.Value, c.IsOnline, c.CompanyName, c.OrganizerId, c.CategoryId,
                    new NewAddressEventCommand(c.Address.Id, c.Address.Street, c.Address.Number, c.Address.Neibourhood, c.Address.PostalCode, c.Address.City, c.Address.State, c.Id)));

            CreateMap<AddressViewModel, NewAddressEventCommand>()
                .ConstructUsing(c => new NewAddressEventCommand(Guid.NewGuid(), c.Street, c.Number, c.Neibourhood, c.PostalCode, c.City, c.State, c.EventId));

            CreateMap<EventViewModel, UpdateEventCommand>()
                .ConstructUsing(c => new UpdateEventCommand(c.Id, c.Name, c.Desc, c.DescriptionFull, c.StartDate, c.FinalDate, c.Free, c.Value, c.IsOnline, c.CompanyName, c.OrganizerId, c.CategoryId));

            CreateMap<EventViewModel, DeleteEventCommand>()
                .ConstructUsing(c => new DeleteEventCommand(c.Id));
        }
    }
}
