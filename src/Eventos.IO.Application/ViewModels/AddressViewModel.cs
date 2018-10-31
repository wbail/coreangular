using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.IO.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel()
        {
            Id = Guid.NewGuid();
        }

        public SelectList States()
        {
            return new SelectList(StatesViewModel.ListStates(), "Uf", "Name");
        }

        [Key]
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Neibourhood { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public Guid EventId { get; set; }

        public override string ToString()
        {
            return Street + ", " + Number + ", " + Neibourhood + ", " + City + " - " + State;
        }
    }
}
