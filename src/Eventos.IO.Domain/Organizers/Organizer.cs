using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Events;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Organizers
{
    public class Organizer : Entity<Organizer>
    {

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public Organizer(Guid id, string name, string email, string cpf)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
        }

        // EF Constructor
        protected Organizer()
        {

        }

        // EF propriedades de navegacao
        public virtual ICollection<Event> Events { get; set; }

        public override bool IsValid()
        {
            return true;
        }
    }
}