using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.IO.Application.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel()
        {
            Id = Guid.NewGuid();
            Address = new AddressViewModel();
            Category = new CategoryViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "First and Last Name")]
        [MaxLength(80, ErrorMessage = "Max value is {1} chars")]
        [MinLength(3, ErrorMessage = "Min value is {1} chars")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short Description is required")]
        [Display(Name = "Short Description")]
        [MaxLength(512, ErrorMessage = "Max value is {1} chars")]
        [MinLength(3, ErrorMessage = "Min value is {1} chars")]
        public string Desc { get; set; }

        [Required(ErrorMessage = "Long Description is required")]
        [Display(Name = "Long Description")]
        [MaxLength(512, ErrorMessage = "Max value is {1} chars")]
        [MinLength(3, ErrorMessage = "Min value is {1} chars")]
        public string DescriptionFull { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [Range(1, 50000)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Value { get; set; }

        [Display(Name = "Will be free?")]
        public bool Free { get; set; }

        [Display(Name = "Will be online?")]
        public bool IsOnline { get; set; }

        [Required(ErrorMessage = "Company Name / Organizer is required")]
        [Display(Name = "Company Name / Organizer")]
        [MaxLength(80, ErrorMessage = "Max value is {1} chars")]
        [MinLength(3, ErrorMessage = "Min value is {1} chars")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Final Date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FinalDate { get; set; }

        public AddressViewModel Address { get; set; }

        public CategoryViewModel Category { get; set; }

        public Guid CategoryId { get; set; }

        public Guid OrganizerId { get; set; }
    }
}
