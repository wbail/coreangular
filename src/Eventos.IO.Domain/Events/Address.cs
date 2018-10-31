using Eventos.IO.Domain.Core.Models;
using System;
using FluentValidation;

namespace Eventos.IO.Domain.Events
{
    public class Address : Entity<Address>
    {
        public string Street { get; private set; }

        public string Number { get; private set; }

        public string Neibourhood { get; private set; }

        public string PostalCode { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public Guid? EventId { get; set; }

        public virtual Event Event { get; private set; }

        public Address(Guid id, string street, string number, string neibourhood, string postalCode, string city, string state, Guid? eventId)
        {
            Id = id;
            Street = street;
            Number = number;
            Neibourhood = neibourhood;
            PostalCode = postalCode;
            City = city;
            State = state;
            EventId = eventId;
        }

        protected Address()
        {

        }

        public override bool IsValid()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Street is mandatory.")
                .Length(2, 150).WithMessage("Street must be in range between 2 and 150 chars.");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("Number is mandatory.")
                .Length(1, 10).WithMessage("Number must be in range between 1 and 10 chars.");

            RuleFor(c => c.Neibourhood)
                .NotEmpty().WithMessage("Neibourhood is mandatory.")
                .Length(2, 150).WithMessage("Neibourhood must be in range between 2 and 150 chars.");

            RuleFor(c => c.PostalCode)
                .Length(8).WithMessage("Postal Code must be 8 chars.");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("City is mandatory.")
                .Length(2, 150).WithMessage("City must be in range between 2 and 150 chars.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("State is mandatory.")
                .Length(2, 150).WithMessage("State must be in range between 2 and 150 chars.");

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}