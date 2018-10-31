using Eventos.IO.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eventos.IO.Domain.Core.Notifications
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _domainNotifications;

        public DomainNotificationHandler()
        {
            _domainNotifications = new List<DomainNotification>();
        }

        public List<DomainNotification> GetNotifications()
        {
            return _domainNotifications;
        }

        public void Handle(DomainNotification message)
        {
            _domainNotifications.Add(message);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: { message.Key } - { message.Value }");
        }

        public bool HasNotifications()
        {
            return _domainNotifications.Any();
        }

        public void Dispose()
        {
            _domainNotifications = new List<DomainNotification>();
        }
    }
}
