using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Interfaces;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Repository;
using FluentValidation.Results;
using System;

namespace Eventos.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _domainNotificationHandler;

        public CommandHandler(IUnityOfWork unityOfWork, IBus bus, IDomainNotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _unityOfWork = unityOfWork;
            _bus = bus;
            _domainNotificationHandler = domainNotificationHandler;
        }

        protected void NotifyErrorValidation(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Console.WriteLine(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            // Todo: Validar se ha alguma validacao de negocio com erro

            if (_domainNotificationHandler.HasNotifications())
            {
                return false;
            }

            var commandResponse = _unityOfWork.Commit();

            if (commandResponse.Success)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Error on save data on database.");
                _bus.RaiseEvent(new DomainNotification("Commit", "Error on save data on database."));
                return false;
            }
        }
    }
}
