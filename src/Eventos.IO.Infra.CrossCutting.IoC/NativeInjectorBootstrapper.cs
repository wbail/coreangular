using AutoMapper;
using Eventos.IO.Application.Interfaces;
using Eventos.IO.Application.Services;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Interfaces;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Events.Commands;
using Eventos.IO.Domain.Events.Repository;
using Eventos.IO.Domain.Events.SystemEvents;
using Eventos.IO.Domain.Repository;
using Eventos.IO.Infra.Data.Context;
using Eventos.IO.Infra.Data.Repository;
using Eventos.IO.Infra.Data.UnityOfWork;
using Events.IO.Infra.CrossCutting.Bus;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Eventos.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IEventAppService, EventAppService>();

            // Domain - Commands
            services.AddScoped<IHandler<NewEventCommand>, EventCommandHandler>();
            services.AddScoped<IHandler<UpdateEventCommand>, EventCommandHandler>();
            services.AddScoped<IHandler<DeleteEventCommand>, EventCommandHandler>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IHandler<RegistredEventEvent>, EventHandlerEvent>();
            services.AddScoped<IHandler<UpdatedEventEvent>, EventHandlerEvent>();
            services.AddScoped<IHandler<DeletedEventEvent>, EventHandlerEvent>();

            // Infra - Data
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddScoped<EventsContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}
