using System;

namespace Eventos.IO.Domain.Events.Commands
{
    public class NewEventCommand : EventCommand
    {
        public NewEventCommand(string name, string desc, string descriptionFull, DateTime startDate, DateTime finalDate,
            bool free, decimal value, bool isOnline, string companyName, Guid organizerId, Guid categoryId, NewAddressEventCommand address)
        {
            Name = name;
            Desc = desc;
            DescriptionFull = descriptionFull;
            StartDate = startDate;
            FinalDate = finalDate;
            Free = free;
            Value = value;
            IsOnline = isOnline;
            CompanyName = companyName;
            OrganizerId = organizerId;
            CategoryId = categoryId;
            Address = address;
        }

        public NewAddressEventCommand Address { get; private set; }
    }
}
