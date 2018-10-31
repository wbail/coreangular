using Eventos.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Events
{
    public class Category : Entity<Category>
    {
        public Category(Guid id)
        {
            Id = id;
        }

        public string Name { get; private set; }

        // EF propriedades de navegacao
        public virtual ICollection<Event> Events { get; set; }

        // Constructor for EF
        protected Category()
        {

        }

        public override bool IsValid()
        {
            return true;
        }
    }
}