using AutoMapper;
using Eventos.IO.Application.ViewModels;
using Eventos.IO.Domain.Events;

namespace Eventos.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Event, EventViewModel>();
            CreateMap<Address, AddressViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
