using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizers;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Events
{
    public class Event : Entity<Event>
    {
        public Event(string name, DateTime startDate, DateTime finalDate,
            bool free, decimal value, bool isOnline, string companyName)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            FinalDate = finalDate;
            Free = free;
            Value = value;
            IsOnline = isOnline;
            CompanyName = companyName;
        }

        private Event()
        {

        }

        public string Name { get; private set; }

        public string Desc { get; private set; }

        public string DescriptionFull { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime FinalDate { get; private set; }

        public bool Free { get; private set; }

        public decimal Value { get; private set; }

        public bool IsOnline { get; private set; }

        public string CompanyName { get; private set; }

        public bool Deleted { get; private set; }

        public ICollection<Tag> Tag { get; private set; }

        public Guid? CategoryId { get; private set; }

        public Guid? AddressId { get; private set; }

        public Guid OrganizerId { get; private set; }
        

        // EF prop de navagacao
        public virtual Category Category { get; private set; }

        public virtual Address Address { get; private set; }

        public virtual Organizer Organizer { get; private set; }

        public void SetAdddress(Address address)
        {
            if (!address.IsValid())
            {
                return;
            }

            Address = address;
        }

        public void SetCategory(Category category)
        {
            if (!category.IsValid())
            {
                return;
            }

            Category = category;
        }

        public void DeleteEvent()
        {
            // Todo: Deve validar alguma regra?
            Deleted = true;
        }

        public override bool IsValid()
        {
            Validate();
            return ValidationResult.IsValid;
        }

        #region Validations

        private void Validate()
        {
            ValidateName();
            ValidateValue();
            ValidateDate();
            ValidateIsOnline();
            ValidationResult = Validate(this);

            // Validacoes adicionais
            ValidateAddress();
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The name not empty.")
                .Length(2, 80).WithMessage("The name must have between 2 and 80 chars.");
        }

        private void ValidateValue()
        {
            if (!Free)
            {
                RuleFor(c => c.Value)
                    .ExclusiveBetween(1, 50000)
                    .WithMessage("Value must be between 1.00 and 50.000");
            }

            if (Free)
            {
                RuleFor(c => c.Value)
                    .ExclusiveBetween(0, 0).When(e => e.Free)
                    .WithMessage("The event is free. Dont must have value.");
            }
        }

        private void ValidateDate()
        {
            RuleFor(c => c.FinalDate)
                .GreaterThan(c => c.StartDate)
                .WithMessage("Final Date must be greater than Start Date");

            RuleFor(c => c.StartDate)
                .LessThan(c => c.FinalDate)
                .WithMessage("Start Date must be less than Final Date");
        }

        private void ValidateIsOnline()
        {
            if (IsOnline)
            {
                RuleFor(c => c.Address)
                    .Null().When(c => c.IsOnline)
                    .WithMessage("The event dont must have address if is online.");
            } else
            {
                RuleFor(c => c.Address)
                    .NotNull()
                    .WithMessage("The event must have an address.");
            }
        }

        private void ValidateAddress()
        {
            if (IsOnline || Address.IsValid())
            {
                return;
            }

            foreach (var error in Address.ValidationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        #endregion

        public static class EventFactory
        {
            public static Event NewEventFull(Guid id, string desc, string descriptionFull, string name, DateTime startDate, DateTime finalDate, 
                bool free, decimal value, bool isOnline, string companyName, Guid organizerId, Address addess, Guid categoryId)
            {
                var ev = new Event()
                {
                    Id = id,
                    Name = name,
                    StartDate = startDate,
                    FinalDate = finalDate,
                    Free = free,
                    Value = value,
                    IsOnline = isOnline,
                    CompanyName = companyName,
                    Address = addess,
                    CategoryId = categoryId,
                    OrganizerId = organizerId
                };

                if (organizerId != null)
                {
                    ev.OrganizerId = organizerId;
                }

                if (isOnline)
                {
                    ev.Address = null;
                }

                return ev;
            }
        }
    }
}